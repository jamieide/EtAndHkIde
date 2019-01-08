using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public IndexModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> RecentArticles { get; set; }
        public IEnumerable<PageMetadata> FeaturedArticles { get; set; }
        public IEnumerable<PageMetadata> RecentBlogEntries { get; set; }

        public void OnGet()
        {
            RecentArticles = _siteRepository.GetPages("/Articles")
                .OrderByDescending(x => x.PublishDate)
                .Take(10);

            FeaturedArticles = _siteRepository.GetPages("/Articles")
                .Where(x => x.Tags.Contains(TagValues.Featured))
                .OrderByDescending(x => x.PublishDate);

            RecentBlogEntries = _siteRepository.GetPages("/Blog")
                .OrderByDescending(x => x.PublishDate)
                .Take(10);
        }
    }

}