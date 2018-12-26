using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ExifLib;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemoryContentsRepository : IContentsRepository
    {
        private readonly Lazy<IList<ContentItem>> _pages;
        private int _imageCount;

        public InMemoryContentsRepository(IHostingEnvironment hostingEnvironment)
        {
            BuildImageList(hostingEnvironment.WebRootFileProvider);
            //BuildImageCollections(hostingEnvironment.WebRootFileProvider);
            _pages = new Lazy<IList<ContentItem>>(LoadPages);
        }

        public IEnumerable<ContentItem> GetPages(int? count = null)
        {
            var query = _pages.Value
                .OrderByDescending(x => x.PublishDate);
            if (count.HasValue && count.Value > 0)
            {
                return query.Take(count.Value);
            }
            return _pages.Value;
        }

        public IEnumerable<ContentItem> GetHighlightPages(int? count)
        {
            var highlightPagePaths = new[] {"MillersForACentury", "Recollections", "MillersForFiveGenerations"};
            var query = _pages.Value
                .Where(x => highlightPagePaths.Contains(x.Path))
                .OrderByDescending(x => x.PublishDate);
            if (count.HasValue && count.Value > 0)
            {
                return query.Take(count.Value);
            }

            return query;
        }

        public int ImageCount() => _imageCount;

        private static IList<ContentItem> LoadPages()
        {
            var pages = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(PageModel).IsAssignableFrom(x) && typeof(IContent).IsAssignableFrom(x))
                .ToList();

            var contentItems = new List<ContentItem>();
            const string pattern = "^EtAndHkIde.Pages.(.+)Model$";
            var regex = new Regex(pattern);
            foreach (var page in pages)
            {
                // Pages must have parameterless ctor
                // This will be a problem if I need to DI into a PageModel
                if (Activator.CreateInstance(page) is IContent contentPage && contentPage.PublishDate.HasValue)
                {
                    var match = regex.Match(page.FullName);
                    if (match.Success)
                    {
                        var path = match.Groups[1].Value.Replace(".", "/");
                        var contentItem = new ContentItem(path, contentPage);
                        contentItems.Add(contentItem);
                    }
                }
            }

            return contentItems;
        }

        private void BuildImageList(IFileProvider webRootFileProvider)
        {
            var imageExtensions = new[] { "jpg" };
            var fileNames = new List<string>();
            var imageCollections = new Dictionary<string, List<string>>();

            //void EnumerateImages(IDirectoryContents directoryContents)
            //{
            //    foreach (var directoryContent in directoryContents)
            //    {
            //        if (directoryContent.IsDirectory)
            //        {
            //            var fileProvider = new PhysicalFileProvider(directoryContent.PhysicalPath);
            //            EnumerateImages(fileProvider.GetDirectoryContents(""));
            //        }
            //        else
            //        {
            //            if (imageExtensions.Contains(directoryContent.))
            //            {

            //            }
            //            var fileName = directoryContent.Name;
            //            fileNames.Add(fileName);
            //        }
            //    }
            //}

            string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
            {
                if (exifReader.GetTagValue<string>(exifTag, out var result))
                {
                    return result;
                }

                return "";
            }

            var imageList = new Dictionary<string, ImageInfo>();
            void EnumerateImages2(string parent, IFileProvider fileProvider)
            {
                var contents = fileProvider.GetDirectoryContents("");
                foreach (var content in contents)
                {
                    if (content.IsDirectory)
                    {
                        var subFileProvider = new PhysicalFileProvider(content.PhysicalPath);
                        EnumerateImages2(content.Name, subFileProvider);
                    }
                    else
                    {
                        var fileInfo = fileProvider.GetFileInfo(content.Name);
                        if (fileInfo.Name.EndsWith(".jpg"))
                        {
                            try
                            {
                                using (var exifReader = new ExifReader(fileInfo.PhysicalPath))
                                {
                                    imageList.Add(fileInfo.PhysicalPath, new ImageInfo()
                                    {
                                        Path = fileInfo.PhysicalPath,
                                        Title = GetImageMetadata(exifReader, ExifTags.XPTitle),
                                        Description = GetImageMetadata(exifReader, ExifTags.XPComment),
                                        Copyright = GetImageMetadata(exifReader, ExifTags.Copyright)
                                    });
                                }
                            }
                            catch (ExifLibException)
                            {
                                // swallow the exception that occurs when there is no EXIF data
                                imageList.Add(fileInfo.PhysicalPath, new ImageInfo());
                            }
                        }
                    }
                }

                _imageCount = imageList.Count;
            }           

            var contentFileInfo = webRootFileProvider.GetFileInfo("content");
            EnumerateImages2(null, new PhysicalFileProvider(contentFileInfo.PhysicalPath));

            //EnumerateImages(webRootFileProvider.GetDirectoryContents("content"));
        }

        private void BuildImageCollections(IFileProvider webRootFileProvider)
        {
            // easier to just recurse?
            var fileCollections = new Dictionary<string, List<string>>();
            var subDirectories = webRootFileProvider.GetDirectoryContents("content").Where(x => x.IsDirectory);
            foreach (var subDirectory in subDirectories)
            {
                var subFileProvider = new PhysicalFileProvider(subDirectory.PhysicalPath);
                var files = subFileProvider
                    .GetDirectoryContents("").Where(x => !x.IsDirectory)
                    .Select(x => $"content/{subDirectory.Name}/{x.Name}");
                fileCollections.Add(subDirectory.Name, files.ToList());

            }
        }

        private class ImageInfo
        {
            public string Path { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Copyright { get; set; }
        }
    }
}