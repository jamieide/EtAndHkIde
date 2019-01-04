using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    /// <summary>
    /// In memory implementation of IContentsRepository. Register as singleton.
    /// </summary>
    public class InMemorySiteRepository : ISiteRepository
    {
        private readonly PageMetadataCollection _pageMetadataCollection;
        private readonly FileMetadataCollection _fileMetadataCollection;
        private readonly IEnumerable<TagType> _tagTypes;
        private readonly IEnumerable<Tag> _tags;

        public InMemorySiteRepository(MetadataFactory factory)
        {
            _pageMetadataCollection = factory.BuildPageMetadataCollection();
            _fileMetadataCollection = factory.BuildFileMetadataCollection();
            _tagTypes = factory.GetTagTypes();
            _tags = factory.GetTags();
        }

        public IEnumerable<PageMetadata> GetPages()
        {
            return _pageMetadataCollection
                .Where(x => x.PublishDate.HasValue)
                .OrderByDescending(x => x.PublishDate.Value);
        }

        public IEnumerable<PageMetadata> GetDraftPages()
        {
            return _pageMetadataCollection
                .Where(x => !x.PublishDate.HasValue);
        }

        public PageMetadata GetPage(string path)
        {
            if (_pageMetadataCollection.TryGetValue(path, out var pageMetadata))
            {
                return pageMetadata;
            }

            return null;
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

        public IDictionary<Tag, IEnumerable<PageMetadata>> GetPagesByTag()
        {
            return (from p in _pageMetadataCollection
                    from t in p.Tags
                    select new
                    {
                        Page = p,
                        Tag = t
                    }).GroupBy(k => k.Tag)
                .ToDictionary(k => k.Key, v => v.Select(x => x.Page));

        }

        public IEnumerable<PageMetadata> GetPageMetadatasForTag(Tag tag)
        {
            return _pageMetadataCollection.Where(x => x.Tags.Contains(tag));
        }

        public PageMetadata GetPageMetadata(string path)
        {
            if (_pageMetadataCollection.TryGetValue(path, out var pageMetadata))
            {
                return pageMetadata;
            }

            return null;
        }

        public IEnumerable<FileMetadata> GetImages(string path)
        {
            return _fileMetadataCollection.Where(x => x.Path.StartsWith(path, StringComparison.OrdinalIgnoreCase));
        }

        public FileMetadata GetImage(string path, string name)
        {
            if (_fileMetadataCollection.TryGetValue($"{path}/{name}", out var contentItem))
            {
                return contentItem;
            }

            return null;
        }

        public IEnumerable<TagType> GetTagTypes() => _tagTypes;

        public IEnumerable<Tag> GetTags() => _tags;
    }
}