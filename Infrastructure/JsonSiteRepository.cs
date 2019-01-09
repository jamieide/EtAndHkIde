﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace EtAndHkIde.Infrastructure
{
    // todo ToList? Return IQueryable?

    public class JsonSiteRepository : ISiteRepository
    {
        private readonly SiteIndex _siteIndex;
        private readonly IEnumerable<string> _tags;

        public JsonSiteRepository(IHostingEnvironment hostingEnvironment)
        {
            var indexPath = Path.Combine(hostingEnvironment.WebRootPath, "index.json");
            _siteIndex = JsonConvert.DeserializeObject<SiteIndex>(File.ReadAllText(indexPath));

            // todo sort tags
            _tags = _siteIndex.Pages.SelectMany(x => x.Tags).Distinct();
        }

        public IEnumerable<PageMetadata> GetPages(string path)
        {
            var query = _siteIndex.Pages.Where(x => x.PublishDate.HasValue);
            if (path.HasValue())
            {
                query = query.Where(x => x.Path.StartsWith(path + '/', StringComparison.OrdinalIgnoreCase));
            }

            return query;
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

        public IDictionary<string, IEnumerable<PageMetadata>> GetPagesByTag()
        {
            // todo currently includes all pages
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

        public IEnumerable<string> GetTags() => _tags;
    }
}