﻿using ExifLib;
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
        private readonly string _articlesPath;

        public MetadataFactory(IHostingEnvironment hostingEnvironment)
        {
            _articlesPath = Path.Combine(hostingEnvironment.WebRootPath, "articles");
        }

        public PageMetadataCollection BuildPageMetadataCollection()
        {
            var pageMetadataCollection = new PageMetadataCollection();

            // Get all pages that extend SitePageModel
            var sitePageModelTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract)
               .ToList();

            var sitePageModels = new List<SitePageModel>();
            foreach (var sitePageModelType in sitePageModelTypes)
            {
                // get page
                var sitePageModel = (SitePageModel)Activator.CreateInstance(sitePageModelType);
                sitePageModels.Add(sitePageModel);
                var pageMetadata = new PageMetadata(sitePageModel);
                pageMetadataCollection.Add(pageMetadata);
            }

            SetRelatedPages(sitePageModels, pageMetadataCollection);

            return pageMetadataCollection;
        }

        private void SetRelatedPages(IEnumerable<SitePageModel> sitePageModels, PageMetadataCollection pageMetadatas)
        {
            foreach (var sitePageModel in sitePageModels)
            {
                if (!sitePageModel.RelatedSitePageModels.Any())
                {
                    continue;
                }

                foreach (var relatedSitePageModel in sitePageModel.RelatedSitePageModels)
                {
                    var sourcePageMetadata = pageMetadatas[sitePageModel.Path];
                    var targetPageMetadata = pageMetadatas[relatedSitePageModel.Path];
                    if (!sourcePageMetadata.RelatedPages.Contains(targetPageMetadata))
                    {
                        sourcePageMetadata.RelatedPages.Add(targetPageMetadata);
                    }
                    if (!targetPageMetadata.RelatedPages.Contains(sourcePageMetadata))
                    {
                        targetPageMetadata.RelatedPages.Add(sourcePageMetadata);
                    }
                }
            }
        }

        // todo only indexes jpg
        public FileMetadataCollection BuildFileMetadataCollection()
        {
            var fileMetadataCollection = new FileMetadataCollection();
            var pathStartIndex = _articlesPath.LastIndexOf("wwwroot", StringComparison.OrdinalIgnoreCase) + 7;
            PopulateContentItemCollection(_articlesPath, fileMetadataCollection, pathStartIndex);
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