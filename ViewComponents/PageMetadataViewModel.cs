using System.Collections.Generic;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.ViewComponents
{
    public class PageMetadataViewModel
    {
        public PageMetadata Page { get; set; }
        public IEnumerable<PageMetadata> RelatedPages { get; set; }
    }
}