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

        public ContentPageCollection BuildContentPageCollection()
        {
            var contentPages = new ContentPageCollection();

            const string pagesNamespace = "EtAndHkIde.Pages";
            var regex = new Regex("^EtAndHkIde.Pages(..+)Model$", RegexOptions.Compiled);

            // Get all pages that extend ContentPageModel
            var contentPageModels = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ContentPageModel).IsAssignableFrom(x) && x.Namespace.StartsWith(pagesNamespace))
                .Select(x => new
                {
                    Type = x,
                    Path = regex.Replace(x.FullName, "$1").Replace('.', '/')
                }).ToList();

            foreach (var contentPageModel in contentPageModels)
            {
                // get page
                var contentPageModelInstance = (ContentPageModel)Activator.CreateInstance(contentPageModel.Type);
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
                    Path = contentPageModel.Path,
                    Title = contentPageModelInstance.Title,
                    Description = contentPageModelInstance.Description,
                    PublishDate = contentPageModelInstance.PublishDate,
                    IsHighlight = contentPageModelInstance.IsHighlight
                };
                contentPages.Add(contentPage);
            }

            return contentPages;
        }

        public ContentItemCollection BuildContentItemCollection()
        {
            var contentItems = new ContentItemCollection();
            var pathStartIndex = _contentsPath.LastIndexOf("wwwroot", StringComparison.OrdinalIgnoreCase) + 7;
            PopulateContentItemCollection(_contentsPath, contentItems, pathStartIndex);
            return contentItems;
        }

        private static void PopulateContentItemCollection(string physicalPath, ContentItemCollection contentItemCollection, int pathStartIndex)
        {
            var fileProvider = new PhysicalFileProvider(physicalPath);
            foreach (var directoryContent in fileProvider.GetDirectoryContents(""))
            {
                if (directoryContent.IsDirectory)
                {
                    PopulateContentItemCollection(directoryContent.PhysicalPath, contentItemCollection, pathStartIndex);
                }
                else
                {
                    if (directoryContent.Name.EndsWith(".jpg"))
                    {
                        var contentItem = new ContentItem()
                        {
                            FileName = directoryContent.Name,
                            Path = directoryContent.PhysicalPath.Substring(pathStartIndex).Replace('\\', '/')
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
                        contentItemCollection.Add(contentItem);
                    }
                }
            }
        }
            private static string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
            {
                return exifReader.GetTagValue<string>(exifTag, out var result) ? result : "";
            }



    }
}