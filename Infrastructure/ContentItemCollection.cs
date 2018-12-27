using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class ContentItemCollection : KeyedCollection<string, ContentItem>
    {
        protected override string GetKeyForItem(ContentItem item)
        {
            return item.Path;
        }
    }
}