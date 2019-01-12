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

        public IEnumerable<PageMetadata> RecentPages { get; set; }
        public IEnumerable<PageMetadata> FeaturePages { get; set; }

        public void OnGet()
        {
            RecentPages = _siteRepository.GetPages(null)
                .OrderByDescending(x => x.PublishDate)
                .Take(10);
            FeaturePages = _siteRepository.GetPages(null)
                .Where(x => x.Tags.Contains(TagValues.Featured));
        }
    }

}