using ExifLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EtAndHkIde.Infrastructure
{
    // TODO Check PreviewImage paths

    public class JsonSiteIndexFactory : ISiteIndexFactory
    {
        private const string IndexFileName = "index.json";
        private const string RelatedPagesFileName = "index-relatedPages.json";

        private readonly IWebHostEnvironment _hostingEnvironment;

        public JsonSiteIndexFactory(IWebHostEnvironment hostEnvironment)
        {
            _hostingEnvironment = hostEnvironment;
        }

        public void BuildIndex()
        {
            var siteIndex = new SiteIndex();
            BuildPageIndex(siteIndex);
            BuildImageIndex(siteIndex);

            AddRelatedPages(siteIndex);

            // write index.json to wwwroot
            var path = Path.Combine(_hostingEnvironment.WebRootPath, IndexFileName);
            var jsonSiteIndex = JsonConvert.SerializeObject(siteIndex);
            File.WriteAllText(path, jsonSiteIndex);
        }

        private static void BuildPageIndex(SiteIndex siteIndex)
        {
            string GetViewEnginePath(Type sitePageModelType)
            {
                // should be same as IActionDescriptorCollectionProvider.ViewEnginePath, which could be used to check validity
                // Gets the path to the page assuming that the namespace is correct and that the class name ends with Model
                var fullName = sitePageModelType.FullName;
                var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
                var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
                return fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
            }

            // Get all pages that extend SitePageModel
            var sitePageModelTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract)
                .ToList();

            foreach (var sitePageModelType in sitePageModelTypes)
            {
                var path = GetViewEnginePath(sitePageModelType);
                var sitePageModel = (SitePageModel)Activator.CreateInstance(sitePageModelType);
                var pageMetadata = new PageMetadata(path, sitePageModel);
                siteIndex.Pages.Add(pageMetadata);
            }
        }

        private void BuildImageIndex(SiteIndex siteIndex)
        {
            // todo could move to json, e.g. indexSettings.json
            var imageDirectories = new[] { "pages" };
            foreach (var imageDirectory in imageDirectories)
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, imageDirectory);
                if (!Directory.Exists(path))
                {
                    throw new Exception($"Invalid directory '{path}'.");
                }
                var fileProvider = new PhysicalFileProvider(path);
                CrawlImageDirectory(fileProvider, siteIndex);
            }
        }

        private void CrawlImageDirectory(IFileProvider fileProvider, SiteIndex siteIndex)
        {
            string GetRelativePath(string physicalPath)
            {
                return "/" + Path.GetRelativePath(_hostingEnvironment.WebRootPath, physicalPath).Replace('\\', '/');
            }

            // crawl images
            var images = fileProvider.GetDirectoryContents("")
                .Where(x => !x.IsDirectory && x.Name.EndsWith(".jpg"))
                .ToDictionary(k => k.Name, StringComparer.OrdinalIgnoreCase);
            foreach (var image in images.Values)
            {
                if (image.Name.EndsWith("-thumb.jpg"))
                {
                    continue;
                }

                var imageMetadata = new ImageMetadata()
                {
                    Path = GetRelativePath(image.PhysicalPath)
                };

                try
                {
                    using (var exifReader = new ExifReader(image.PhysicalPath))
                    {
                        imageMetadata.Title = GetImageMetadata(exifReader, ExifTags.XPTitle);
                        imageMetadata.Description = GetImageMetadata(exifReader, ExifTags.XPComment);
                        imageMetadata.Copyright = GetImageMetadata(exifReader, ExifTags.Copyright);
                        var tags = GetImageMetadata(exifReader, ExifTags.XPKeywords);
                        if (!string.IsNullOrWhiteSpace(tags))
                        {
                            imageMetadata.Tags = tags.Split(';', ',').Select(x => x.Trim()).ToArray();
                        }
                    }
                }
                catch (ExifLibException)
                {
                    // swallow the exception that occurs when there is no EXIF data
                }

                var thumbnailName = image.Name.Replace(".jpg", "-thumb.jpg");
                if (images.TryGetValue(thumbnailName, out var thumbnail))
                {
                    imageMetadata.ThumbnailPath = GetRelativePath(thumbnail.PhysicalPath);
                }
                else
                {
                    imageMetadata.ThumbnailPath = imageMetadata.Path;
                }
                siteIndex.Images.Add(imageMetadata);
            }

            // crawl subdirectories
            var subDirectories = fileProvider.GetDirectoryContents("")
                .Where(x => x.IsDirectory);
            foreach (var subDirectory in subDirectories)
            {
                var subFileProvider = new PhysicalFileProvider(subDirectory.PhysicalPath);
                CrawlImageDirectory(subFileProvider, siteIndex);
            }
        }

        private static string GetImageMetadata(ExifReader exifReader, ExifTags exifTag)
        {
            return exifReader.GetTagValue<string>(exifTag, out var result) ? result : "";
        }

        // Could get fancy and define an interface for post-build processors but no need to be enterprisey
        // todo just set paths in SitePageModel??
        private void AddRelatedPages(SiteIndex siteIndex)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, RelatedPagesFileName);
            if (!File.Exists(path))
            {
                return;
            }

            var contents = File.ReadAllText(path);
            var relatedPageSets = JsonConvert.DeserializeObject<IEnumerable<IEnumerable<string>>>(contents);
            foreach (var relatedPageSet in relatedPageSets)
            {
                var pageMetadatas = siteIndex.Pages.Where(x => relatedPageSet.Contains(x.Path));
                foreach (var pageMetadata in pageMetadatas)
                {
                    pageMetadata.RelatedPagePaths = relatedPageSet.Where(x => !string.Equals(x, pageMetadata.Path, StringComparison.OrdinalIgnoreCase));
                }
            }
        }

    }
}
