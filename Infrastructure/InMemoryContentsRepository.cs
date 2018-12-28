using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemoryContentsRepository : IContentsRepository
    {
        private readonly ContentPageCollection _contentPages;
        private readonly ContentItemCollection _contentItems;

        public InMemoryContentsRepository(ContentPageCollectionFactory factory)
        {
            _contentPages = factory.BuildContentPageCollection();
            _contentItems = factory.BuildContentItemCollection();
        }

        public IEnumerable<ContentPage> GetPages(int? count)
        {
            var query = _contentPages
                .Where(x => x.PublishDate.HasValue);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.OrderByDescending(x => x.PublishDate).ToList();
        }

        public IEnumerable<ContentPage> GetHighlightPages(int? count)
        {
            var query = _contentPages.Where(x => x.IsHighlight);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query;
        }

        public IEnumerable<ContentItem> GetImages(string path)
        {
            return _contentItems.Where(x => x.Path.StartsWith($"/content{path}", StringComparison.OrdinalIgnoreCase));
        }

        public ContentItem GetImage(string path, string name)
        {
            if (_contentItems.TryGetValue($"/content{path}/{name}", out var contentItem))
            {
                return contentItem;
            }

            return null;
        }
    }
}