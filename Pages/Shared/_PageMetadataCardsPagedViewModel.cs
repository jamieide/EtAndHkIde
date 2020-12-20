using EtAndHkIde.Infrastructure;
using System.Collections.Generic;

namespace EtAndHkIde.Pages.Shared
{
    public class _PageMetadataCardsPagedViewModel
    {
        public _PageMetadataCardsPagedViewModel(string prefix, IDictionary<int, IEnumerable<PageMetadata>> pages)
        {
            Prefix = prefix;
            Pages = pages;
        }

        public string Prefix { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> Pages { get; set; }
    }
}
