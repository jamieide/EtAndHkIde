using ExifLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemoryContentsRepository : IContentsRepository
    {
        private ContentPageCollection _contentPages;

        public InMemoryContentsRepository(IHostingEnvironment hostingEnvironment)
        {
            SetContentPages(hostingEnvironment);
        }

        public ContentPageCollection GetContentPages() => _contentPages;

        public IEnumerable<ContentPage> GetPublishedContentPages(int? count, ContentPageType type)
        {
            var query = _contentPages
                .Where(x => x.PublishDate.HasValue && x.ContentPageType == type);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.OrderByDescending(x => x.PublishDate).ToList();
        }

        public IEnumerable<ContentItem> GetImages(string path)
        {
            if (_contentPages.TryGetValue(path, out var contentPage))
            {
                return contentPage.ContentItems;
            }

            return Enumerable.Empty<ContentItem>();
        }

        public ContentItem GetImage(string path, string imageFileName)
        {
            if (_contentPages.TryGetValue(path, out var contentPage))
            {
                if (contentPage.ContentItems.TryGetValue(imageFileName, out var contentItem))
                {
                    return contentItem;
                }
            }

            return null;
        }

        string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
        {
            if (exifReader.GetTagValue<string>(exifTag, out var result))
            {
                return result;
            }

            return "";
        }

        private void SetContentPages(IHostingEnvironment hostingEnvironment)
        {
            _contentPages = new ContentPageCollection();

            var contentsDirectory = new PhysicalFileProvider(Path.Combine(hostingEnvironment.WebRootPath, "content"));

            const string pattern = "^EtAndHkIde.Pages.(.+)Model$";
            var regex = new Regex(pattern);

            var contentPageModels = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ContentPageModel).IsAssignableFrom(x))
                .ToList();

            foreach (var contentPageModel in contentPageModels)
            {
                var match = regex.Match(contentPageModel.FullName);
                if (!match.Success)
                {
                    // todo log error
                    continue;
                }

                // get page
                var contentPageModelInstance = (ContentPageModel)Activator.CreateInstance(contentPageModel);
                var type = ContentPageType.Undefined;
                if (contentPageModelInstance is ArticlePageModel)
                {
                    type = ContentPageType.Article;
                }
                else if (contentPageModelInstance is GalleryPageModel)
                {
                    type = ContentPageType.Gallery;
                }

                var contentPage = new ContentPage()
                {

                    ContentPageType = type,
                    Path = "/" + match.Groups[1].Value.Replace(".", "/"),
                    Title = contentPageModelInstance.Title,
                    Description = contentPageModelInstance.Description,
                    PublishDate = contentPageModelInstance.PublishDate
                };

                // get content items
                foreach (var directoryContent in contentsDirectory.GetDirectoryContents(contentPage.Path))
                {
                    // todo could optimize getting the relative path
                    // nested wwwroot on azure https://github.com/aspnet/AspNetCore/issues/1636
                    var wwwrootIndex = directoryContent.PhysicalPath.LastIndexOf("wwwroot", StringComparison.OrdinalIgnoreCase);
                    var relativePath = directoryContent.PhysicalPath.Substring(wwwrootIndex + 7).Replace("\\", "/");

                    if (directoryContent.Name.EndsWith(".jpg"))
                    {
                        var contentItem = new ContentItem()
                        {
                            FileName = directoryContent.Name,
                            Path = relativePath
                        };
                        try
                        {
                            using (var exifReader = new ExifReader(directoryContent.PhysicalPath))
                            {
                                contentItem.Title = GetImageMetadata(exifReader, ExifTags.XPTitle);
                                contentItem.Description = GetImageMetadata(exifReader, ExifTags.XPComment);
                                contentItem.Copyright = GetImageMetadata(exifReader, ExifTags.Copyright);
                            }
                        }
                        catch (ExifLibException)
                        {
                            // swallow the exception that occurs when there is no EXIF data

                        }
                        contentPage.ContentItems.Add(contentItem);
                    }
                }

                _contentPages.Add(contentPage);
            }
        }
    }
}