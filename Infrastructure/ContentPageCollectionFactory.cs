using ExifLib;
using Microsoft.Extensions.FileProviders;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EtAndHkIde.Infrastructure
{
    public class ContentPageCollectionFactory
    {
        private readonly string _contentsPath;

        public ContentPageCollectionFactory(string contentsPath)
        {
            _contentsPath = contentsPath;
        }

        string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
        {
            if (exifReader.GetTagValue<string>(exifTag, out var result))
            {
                return result;
            }

            return "";
        }

        public ContentPageCollection Build()
        {
            var contentsDirectory = new PhysicalFileProvider(_contentsPath);
            var contentPages = new ContentPageCollection();

            const string pagesNamespace = "EtAndHkIde.Pages";
            var regex = new Regex("^EtAndHkIde.Pages(..+)Model$", RegexOptions.Compiled);

            // Get all pages that extend ContentPageModel
            var contentPageModels = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ContentPageModel).IsAssignableFrom(x) && x.Namespace.StartsWith(pagesNamespace))
                .Select(x => (type: x, path: regex.Replace(x.FullName, "$1").Replace('.', '/')))
                .ToList();

            foreach (var contentPageModel in contentPageModels)
            {
                var contentPage = BuildContentPage(contentPageModel);

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

                contentPages.Add(contentPage);
            }

            return contentPages;
        }

        private static ContentPage BuildContentPage((Type type, string path) page)
        {
            //var regex = new Regex("^EtAndHkIde.Pages(..+)Model$");
            //var match = regex.Match(contentPageModel.FullName);

            // get page
            var contentPageModelInstance = (ContentPageModel)Activator.CreateInstance(page.type);
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
                Path = page.path, //.Groups[1].Value.Replace(".", "/"),
                Title = contentPageModelInstance.Title,
                Description = contentPageModelInstance.Description,
                PublishDate = contentPageModelInstance.PublishDate,
                IsHighlight = contentPageModelInstance.IsHighlight
            };
            return contentPage;
        }
    }
}