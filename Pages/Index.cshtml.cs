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

        public int AllPagesCount { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> AllPages { get; set; }

        public void OnGet()
        {
            RecentPages = _siteRepository.GetPages(null)
                .OrderByDescending(x => x.PublishDate)
                .Take(PageSize);

            FeaturePages = _siteRepository.GetPages(null)
                .Where(x => x.Tags.Contains(TagValues.System.Featured));

            var allPages = _siteRepository.GetPages(null);
            AllPages = BuildPages(allPages);
        }

        private IDictionary<int, IEnumerable<PageMetadata>> BuildPages(IEnumerable<PageMetadata> allPages)
        {
            var pageCount = allPages.Count() % PageSize == 0 ? allPages.Count() / PageSize : allPages.Count() / PageSize + 1;
            var dict = new Dictionary<int, IEnumerable<PageMetadata>>();
            for (int i = 0; i < pageCount; i++)
            {
                var pages = allPages.Skip(i * PageSize).Take(PageSize);
                dict.Add(i + 1, pages);
            }
            return dict;
        }
    }

}