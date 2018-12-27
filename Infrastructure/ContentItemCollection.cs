using System;
using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class ContentItemCollection : KeyedCollection<string, ContentItem>
    {
        public ContentItemCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override string GetKeyForItem(ContentItem item)
        {
            return item.FileName;
        }
    }
}