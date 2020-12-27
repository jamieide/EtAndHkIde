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
            //BuildImageIndex(siteIndex);

            //AddRelatedPages(siteIndex);

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
    }
}
