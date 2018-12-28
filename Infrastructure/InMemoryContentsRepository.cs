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

        public InMemoryContentsRepository(ContentPageCollectionFactory factory)
        {
            _contentPages = factory.Build();
            //SetContentPages(hostingEnvironment);
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
            if (_contentPages.TryGetValue(path, out var contentPage))
            {
                return contentPage.ContentItems;
            }

            return Enumerable.Empty<ContentItem>();
        }

        public ContentItem GetImage(string path, string imageFileName)
        {
            if (_contentPages.TryGetValue(path, out var contentPage))
            {
                if (contentPage.ContentItems.TryGetValue(imageFileName, out var contentItem))
                {
                    return contentItem;
                }
            }

            return null;
        }
    }
}