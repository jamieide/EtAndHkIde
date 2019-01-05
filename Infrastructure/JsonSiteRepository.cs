using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace EtAndHkIde.Infrastructure
{
    public class JsonSiteRepository : ISiteRepository
    {
        private readonly SiteIndex _siteIndex;
        private readonly IEnumerable<Tag> _tags;
        private readonly IEnumerable<TagType> _tagTypes;

        public JsonSiteRepository(IHostingEnvironment hostingEnvironment)
        {
            var indexPath = Path.Combine(hostingEnvironment.WebRootPath, "index.json");
            _siteIndex = JsonConvert.DeserializeObject<SiteIndex>(File.ReadAllText(indexPath));

            // todo sort tags
            _tags = _siteIndex.Pages.SelectMany(x => x.Tags).Distinct();
            _tagTypes = _tags.Select(x => x.TagType).Distinct();
        }

        public IEnumerable<PageMetadata> GetPages()
        {
            return _siteIndex.Pages
                .Where(x => x.PublishDate.HasValue);
        }

        public IEnumerable<PageMetadata> GetDraftPages()
        {
            return _siteIndex.Pages
                .Where(x => !x.PublishDate.HasValue);
        }

        public PageMetadata GetPage(string path)
        {
            return _siteIndex.Pages.TryGetValue(path, out var page) ? page : null;
        }

        public IDictionary<Tag, IEnumerable<PageMetadata>> GetPagesByTag()
        {
            return (from p in _siteIndex.Pages
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
            return _siteIndex.Images
                .Where(x => x.Path.StartsWith(path, StringComparison.OrdinalIgnoreCase));
        }

        public ImageMetadata GetImage(string path, string name)
        {
            if (_siteIndex.Images.TryGetValue($"{path}/{name}", out var file))
            {
                return file;
            }
            return null;
        }

        public IEnumerable<TagType> GetTagTypes() => _tagTypes;

        public IEnumerable<Tag> GetTags() => _tags;
    }
}