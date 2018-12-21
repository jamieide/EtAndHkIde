using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemoryContentsRepository : IContentsRepository
    {
        private readonly Lazy<IList<ContentItem>> _contents;

        public InMemoryContentsRepository(IHostingEnvironment hostingEnvironment)
        {
            //BuildImageList(hostingEnvironment.WebRootFileProvider);
            _contents = new Lazy<IList<ContentItem>>(BuildContentItems);
        }

        public IEnumerable<ContentItem> GetPages()
        {
            return _contents.Value;
        }

        public IEnumerable<ContentItem> GetRecentPages(int count)
        {
            return _contents.Value.
                OrderByDescending(x => x.PublishDate)
                .Take(count);
        }

        private static IList<ContentItem> BuildContentItems()
        {
            var pages = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(PageModel).IsAssignableFrom(x) && typeof(IContent).IsAssignableFrom(x))
                .ToList();

            var contentItems = new List<ContentItem>();
            foreach (var page in pages)
            {
                // Pages must have parameterless ctor
                // This will be a problem if I need to DI into a PageModel
                if (Activator.CreateInstance(page) is IContent contentPage && contentPage.PublishDate.HasValue)
                {
                    const string pattern = "^EtAndHkIde.Pages.(.+)Model$";
                    var match = Regex.Match(page.FullName, pattern);
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

        //private void BuildImageList(IFileProvider fileProvider)
        //{
        //    var imageExtensions = new[] {"jpg"};
        //    var fileNames = new List<string>();
        //    void EnumerateImages(IDirectoryContents directoryContents)
        //    {
        //        foreach (var directoryContent in directoryContents)
        //        {
        //            if (directoryContent.IsDirectory)
        //            {
        //                EnumerateImages(fileProvider.GetDirectoryContents(directoryContent.Name));
        //            }
        //            else
        //            {
        //                var file = fileProvider.GetFileInfo(directoryContent.Name);
        //                fileNames.Add(file.Name);
        //            }
        //        }
        //    }

        //    EnumerateImages(fileProvider.GetDirectoryContents("content"));
        //}
    }
}