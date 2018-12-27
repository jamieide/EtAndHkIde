using System;
using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class ContentPageCollection : KeyedCollection<string, ContentPage>
    {
        public ContentPageCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override string GetKeyForItem(ContentPage item)
        {
            return item.Path;
        }
    }
}