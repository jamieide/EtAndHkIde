using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemoryMetadataRepository : IMetadataRepository
    {
        private readonly PageMetadataCollection _pageMetadataCollection;
        private readonly FileMetadataCollection _fileMetadataCollection;

        public InMemoryMetadataRepository(MetadataFactory factory)
        {
            _pageMetadataCollection = factory.BuildPageMetadataCollection();
            _fileMetadataCollection = factory.BuildFileMetadataCollection();
        }

        public IEnumerable<PageMetadata> GetPageMetadatas(int? count)
        {
            var query = _pageMetadataCollection
                .Where(x => x.PublishDate.HasValue);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.OrderByDescending(x => x.PublishDate).ToList();
        }

        public IEnumerable<PageMetadata> GetHighlightPageMetadatas(int? count)
        {
            var query = _pageMetadataCollection.Where(x => x.IsHighlight);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query;
        }

        public IEnumerable<FileMetadata> GetImages(string path)
        {
            return _fileMetadataCollection.Where(x => x.Path.StartsWith($"/content{path}", StringComparison.OrdinalIgnoreCase));
        }

        public FileMetadata GetImage(string path, string name)
        {
            if (_fileMetadataCollection.TryGetValue($"/content{path}/{name}", out var contentItem))
            {
                return contentItem;
            }

            return null;
        }
    }
}