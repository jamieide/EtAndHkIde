using ExifLib;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EtAndHkIde.Infrastructure
{
    public class MetadataFactory
    {
        private readonly string _webRootPath;

        public MetadataFactory(string webRootPath)
        {
            _webRootPath = webRootPath;
        }

        public PageMetadataCollection BuildPageMetadataCollection()
        {
            var pageMetadataCollection = new PageMetadataCollection();

            // Get all pages that extend SitePageModel
            var sitePageModelTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract)
               .ToList();

            foreach (var sitePageModelType in sitePageModelTypes)
            {
                var path = GetViewEnginePath(sitePageModelType);
                var sitePageModel = (SitePageModel)Activator.CreateInstance(sitePageModelType);
                var pageMetadata = new PageMetadata(path, sitePageModel);
                pageMetadataCollection.Add(pageMetadata);
            }
            return pageMetadataCollection;
        }

        private static string GetViewEnginePath(Type sitePageModelType)
        {
            // should be same as IActionDescriptorCollectionProvider.ViewEnginePath, which could be used to check
            var fullName = sitePageModelType.FullName;
            var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
            var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
            return fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
        }

        // todo only indexes jpg
        public ImageMetadataCollection BuildImageMetadataCollection()
        {
            var pathsToIndex = new[] { "articles", "images" };
            var imageCollection = new ImageMetadataCollection();
            var thumbnailPahts = new HashSet<string>();
            foreach (var pathToIndex in pathsToIndex)
            {
                var path = Path.Combine(_webRootPath, pathToIndex);
                var pathStartIndex = path.LastIndexOf("wwwroot", StringComparison.OrdinalIgnoreCase) + 7;
                PopulateImageMetadataCollection(path, imageCollection, thumbnailPahts, pathStartIndex);
            }
            LinkImageThumbnails(imageCollection, thumbnailPahts);
            return imageCollection;
        }

        private static void PopulateImageMetadataCollection(string physicalPath, ImageMetadataCollection imageCollection, ISet<string> thumbnailPaths, int pathStartIndex)
        {
            var fileProvider = new PhysicalFileProvider(physicalPath);
            foreach (var directoryContent in fileProvider.GetDirectoryContents(""))
            {
                if (directoryContent.IsDirectory)
                {
                    PopulateImageMetadataCollection(directoryContent.PhysicalPath, imageCollection, thumbnailPaths, pathStartIndex);
                }
                else
                {
                    if (directoryContent.Name.EndsWith("-thumb.jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        thumbnailPaths.Add(directoryContent.PhysicalPath.Substring(pathStartIndex).Replace('\\', '/'));
                    }
                    else if (directoryContent.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        var imageMetadata = new ImageMetadata()
                        {
                            Path = directoryContent.PhysicalPath.Substring(pathStartIndex).Replace('\\', '/')
                        };
                        try
                        {
                            using (var exifReader = new ExifReader(directoryContent.PhysicalPath))
                            {
                                imageMetadata.Title = GetImageMetadata(exifReader, ExifTags.XPTitle);
                                imageMetadata.Description = GetImageMetadata(exifReader, ExifTags.XPComment);
                                imageMetadata.Copyright = GetImageMetadata(exifReader, ExifTags.Copyright);
                            }
                        }
                        catch (ExifLibException)
                        {
                            // swallow the exception that occurs when there is no EXIF data
                        }
                        imageCollection.Add(imageMetadata);
                    }
                }
            }
        }

        private static void LinkImageThumbnails(ImageMetadataCollection imageCollection, ISet<string> thumbnailPaths)
        {
            foreach (var image in imageCollection)
            {
                var thumbPath = image.Path.Replace(".jpg", "-thumb.jpg");
                image.ThumbnailPath = thumbnailPaths.Contains(thumbPath) ? thumbPath : image.Path;
            }
        }

        private static string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
        {
            return exifReader.GetTagValue<string>(exifTag, out var result) ? result : "";
        }

        public IEnumerable<TagType> GetTagTypes()
        {
            return typeof(TagType)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(TagType))
                .Select(x => (TagType)x.GetValue(null))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Tag> GetTags()
        {
            return typeof(Tag)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(Tag))
                .Select(x => (Tag)x.GetValue(null))
                .OrderBy(x => x.TagType.Name).ThenBy(x => x.Name)
                .ToList();
        }
    }
}