using ExifLib;
using Microsoft.AspNetCore.Hosting;
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
        private readonly string _contentsPath;

        public MetadataFactory(IHostingEnvironment hostingEnvironment)
        {
            _contentsPath = Path.Combine(hostingEnvironment.WebRootPath, "articles");
        }

        public PageMetadataCollection BuildPageMetadataCollection()
        {
            var pageMetadataCollection = new PageMetadataCollection();

            string GetSitePagePath(string fullName)
            {
                var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
                var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
                return fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
            }

            // Get all pages that extend ContentPageModel
            var sitePageModels = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract)
                .Select(x => new
                {
                    Type = x,
                    Path = GetSitePagePath(x.FullName)
                }).ToList();

            foreach (var sitePageModel in sitePageModels)
            {
                // get page
                var sitePageModelInstance = (SitePageModel)Activator.CreateInstance(sitePageModel.Type);
                var pageMetadata = new PageMetadata()
                {
                    Path = sitePageModel.Path,
                    Title = sitePageModelInstance.Title,
                    Description = sitePageModelInstance.Description,
                    PublishDate = sitePageModelInstance.PublishDate,
                    IsHighlight = sitePageModelInstance.IsHighlight,
                    Tags = sitePageModelInstance.Tags,
                    Citation = sitePageModelInstance.Citation
                };
                pageMetadataCollection.Add(pageMetadata);
            }

            return pageMetadataCollection;
        }

        // todo only indexes jpg
        public FileMetadataCollection BuildFileMetadataCollection()
        {
            var fileMetadataCollection = new FileMetadataCollection();
            var pathStartIndex = _contentsPath.LastIndexOf("wwwroot", StringComparison.OrdinalIgnoreCase) + 7;
            PopulateContentItemCollection(_contentsPath, fileMetadataCollection, pathStartIndex);
            return fileMetadataCollection;
        }

        private static void PopulateContentItemCollection(string physicalPath, FileMetadataCollection fileMetadataCollection, int pathStartIndex)
        {
            var fileProvider = new PhysicalFileProvider(physicalPath);
            foreach (var directoryContent in fileProvider.GetDirectoryContents(""))
            {
                if (directoryContent.IsDirectory)
                {
                    PopulateContentItemCollection(directoryContent.PhysicalPath, fileMetadataCollection, pathStartIndex);
                }
                else
                {
                    if (directoryContent.Name.EndsWith(".jpg"))
                    {
                        var fileMetadata = new FileMetadata()
                        {
                            FileName = directoryContent.Name,
                            Path = directoryContent.PhysicalPath.Substring(pathStartIndex).Replace('\\', '/')
                        };
                        try
                        {
                            using (var exifReader = new ExifReader(directoryContent.PhysicalPath))
                            {
                                fileMetadata.Title = GetImageMetadata(exifReader, ExifTags.XPTitle);
                                fileMetadata.Description = GetImageMetadata(exifReader, ExifTags.XPComment);
                                fileMetadata.Copyright = GetImageMetadata(exifReader, ExifTags.Copyright);
                            }
                        }
                        catch (ExifLibException)
                        {
                            // swallow the exception that occurs when there is no EXIF data
                        }
                        fileMetadataCollection.Add(fileMetadata);
                    }
                }
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