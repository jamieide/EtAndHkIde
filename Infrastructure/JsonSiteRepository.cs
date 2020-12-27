using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace EtAndHkIde.Infrastructure
{
    // todo ToList? Return IQueryable?

    public class JsonSiteRepository : ISiteRepository
    {
        private readonly SiteIndex _siteIndex;
        private readonly IEnumerable<string> _tags;

        public JsonSiteRepository(IWebHostEnvironment hostEnvironment)
        {
            var indexPath = Path.Combine(hostEnvironment.WebRootPath, "index.json");
            _siteIndex = JsonConvert.DeserializeObject<SiteIndex>(File.ReadAllText(indexPath));

            _tags = _siteIndex.Pages
                .SelectMany(x => x.Tags)
                .Distinct()
                .OrderBy(x => x, new TagSorter());
        }

        public IEnumerable<PageMetadata> GetPages()
        {
            return _siteIndex.Pages.Where(x => x.PublishDate.HasValue).ToList();
        }

        public IEnumerable<PageMetadata> GetDraftPages()
        {
            return _siteIndex.Pages.Where(x => !x.PublishDate.HasValue).ToList();
        }

        public PageMetadata GetPage(string path)
        {
            if (path.EndsWith('/'))
            {
                path = path.Substring(0, path.Length - 1);
            }
            return _siteIndex.Pages.TryGetValue(path, out var page) ? page : null;
        }

        public IDictionary<string, IEnumerable<PageMetadata>> GetPagesByTag()
        {
            return (from p in _siteIndex.Pages
                    from t in p.Tags
                    orderby p.PublishDate descending 
                    select new
                    {
                        Page = p,
                        Tag = t
                    }).GroupBy(k => k.Tag)
                .ToDictionary(k => k.Key, v => v.Select(x => x.Page));
        }


        public IEnumerable<string> GetTags() => _tags;

        private class TagSorter : IComparer<string>
        {
            private static int CompareTo(string x, string y, ISet<string> tagGroup)
            {
                var containsX = tagGroup.Contains(x);
                var containsY = tagGroup.Contains(y);
                if (containsX ^ containsY) //xor
                {
                    return containsX ? -1 : 1;
                }

                return 0;
            }

            public int Compare(string x, string y)
            {
                var compare = CompareTo(x, y, TagValues.System.All);
                if (compare == 0)
                {
                    compare = CompareTo(x, y, TagValues.People.All);
                    if (compare == 0)
                    {
                        compare = CompareTo(x, y, TagValues.Places.All);
                        if (compare == 0)
                        {
                            return string.CompareOrdinal(x, y);
                        }
                    }
                }

                return compare;
            }
        }
    }
}