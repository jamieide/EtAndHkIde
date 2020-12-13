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

        public const int PageSize = 8;
        public IEnumerable<PageMetadata> RecentPages { get; set; }
        public IEnumerable<PageMetadata> FeaturePages { get; set; }
        public IEnumerable<PageMetadata> AllPages { get; set; }
        public int AllPagesCount { get; set; }

        public void OnGet()
        {
            RecentPages = _siteRepository.GetPages(null)
                .OrderByDescending(x => x.PublishDate)
                .Take(PageSize);
            FeaturePages = _siteRepository.GetPages(null)
                .Where(x => x.Tags.Contains(TagValues.System.Featured));
            AllPages = _siteRepository.GetPages(null);
            if (AllPages.Count() == 0)
            {
                AllPagesCount = 1;
            }
            else
            {
                AllPagesCount = AllPages.Count() % PageSize == 0 ? AllPages.Count() / PageSize : AllPages.Count() / PageSize + 1;
            }
        }
    }

}