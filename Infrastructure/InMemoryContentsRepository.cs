using ExifLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private IList<ContentPage> _contentPages;

        public InMemoryContentsRepository(IHostingEnvironment hostingEnvironment)
        {
            SetContentPages(hostingEnvironment);
        }

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
            var contentsDirectory = new PhysicalFileProvider(Path.Combine(hostingEnvironment.WebRootPath, "content"));

            const string pattern = "^EtAndHkIde.Pages.(.+)Model$";
            var regex = new Regex(pattern);

            var contentPages = new List<ContentPage>();
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
                    Path = match.Groups[1].Value.Replace(".", "/"),
                    Title = contentPageModelInstance.Title,
                    Description = contentPageModelInstance.Description,
                    PublishDate = contentPageModelInstance.PublishDate
                };
                contentPages.Add(contentPage);

                // get assets
                var contentItems = new List<ContentItem>();
                foreach (var directoryContent in contentsDirectory.GetDirectoryContents(contentPage.Path))
                {
                    // todo could optimize getting the relative path
                    var relativePath = directoryContent.PhysicalPath.Substring(directoryContent.PhysicalPath.IndexOf("wwwroot\\", StringComparison.OrdinalIgnoreCase) + 8).Replace("\\", "/");

                    if (directoryContent.Name.EndsWith(".jpg"))
                    {
                        try
                        {
                            using (var exifReader = new ExifReader(directoryContent.PhysicalPath))
                            {
                                contentItems.Add(new ContentItem()
                                {
                                    Path = relativePath,
                                    Title = GetImageMetadata(exifReader, ExifTags.XPTitle),
                                    Description = GetImageMetadata(exifReader, ExifTags.XPComment),
                                    Copyright = GetImageMetadata(exifReader, ExifTags.Copyright),
                                });
                            }
                        }
                        catch (ExifLibException)
                        {
                            // swallow the exception that occurs when there is no EXIF data
                            contentItems.Add(new ContentItem()
                            {
                                Path = relativePath
                            });
                        }
                    }
                }

                contentPage.ContentItems = contentItems;
            }

            _contentPages = contentPages;
        }
    }
}