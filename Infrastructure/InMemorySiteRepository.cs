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
        private readonly ImageMetadataCollection _imageMetadataCollection;
        private readonly IEnumerable<TagType> _tagTypes;
        private readonly IEnumerable<Tag> _tags;

        public InMemorySiteRepository(MetadataFactory factory)
        {
            _pageMetadataCollection = factory.BuildPageMetadataCollection();
            _imageMetadataCollection = factory.BuildImageMetadataCollection();
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
            return _pageMetadataCollection.TryGetValue(path, out var pageMetadata) ? pageMetadata : null;
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

        public IEnumerable<ImageMetadata> GetImages(string path)
        {
            return _imageMetadataCollection
                .Where(x => x.Path.StartsWith(path, StringComparison.OrdinalIgnoreCase));
        }

        public ImageMetadata GetImage(string path, string name)
        {
            if (_imageMetadataCollection.TryGetValue($"{path}/{name}", out var file))
            {
                return file;
            }
            return null;
        }

        public IEnumerable<TagType> GetTagTypes() => _tagTypes;

        public IEnumerable<Tag> GetTags() => _tags;
    }
}