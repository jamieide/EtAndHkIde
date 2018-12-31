using System;
using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadataCollection : KeyedCollection<string, PageMetadata>
    {
        public PageMetadataCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override string GetKeyForItem(PageMetadata item)
        {
            return item.Path;
        }
    }
}