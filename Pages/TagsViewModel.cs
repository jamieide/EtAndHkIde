using EtAndHkIde.Infrastructure;
using System.Collections.Generic;

namespace EtAndHkIde.Pages
{
    public class TagsViewModel
    {
        public Tag Tag { get; set; }
        public IEnumerable<PageMetadata> PageMetadatas { get; set; }
    }
}