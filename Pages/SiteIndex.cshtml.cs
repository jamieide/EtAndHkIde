using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EtAndHkIde.Pages
{
    public class SiteIndexModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public SiteIndexModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<IEnumerable<PageMetadata>> PageMetadataPages { get; set; }

        public void OnGet()
        {
            var pageMetadatas = _siteRepository.GetPageMetadatas(null);
            PageMetadataPages = Partition(pageMetadatas, 10);
        }

        // https://stackoverflow.com/a/438208/12752
        private static IEnumerable<IEnumerable<PageMetadata>> Partition(IEnumerable<PageMetadata> source, int size)
        {
            PageMetadata[] array = null;
            var count = 0;
            foreach (var item in source)
            {
                if (array == null)
                {
                    array = new PageMetadata[size];
                }
                array[count] = item;
                count++;
                if (count == size)
                {
                    yield return array;// new ReadOnlyCollection<PageMetadata>(array);
                    array = null;
                    count = 0;
                }
            }
            if (array != null)
            {
                Array.Resize(ref array, count);
                yield return array;// new ReadOnlyCollection<PageMetadata>(array);
            }
        }
    }
}