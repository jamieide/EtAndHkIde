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
        public IDictionary<int, IEnumerable<PageMetadata>> FeaturePages { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> PhotoPages { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> AllPages { get; set; }

        public void OnGet()
        {
            var allPages = _siteRepository.GetPages(null)
                .OrderByDescending(x => x.PublishDate)
                .ToList();
            AllPages = BuildPages(allPages);

            RecentPages = allPages.Take(PageSize);

            var photoPages = allPages.Where(x => x.Tags.Contains(TagValues.System.Photos));
            PhotoPages = BuildPages(photoPages);

            var featurePages = allPages.Where(x => x.Tags.Contains(TagValues.System.Featured));
            FeaturePages = BuildPages(featurePages);
        }

        private IDictionary<int, IEnumerable<PageMetadata>> BuildPages(IEnumerable<PageMetadata> allPages)
        {
            var pageCount = allPages.Count() % PageSize == 0 ? allPages.Count() / PageSize : allPages.Count() / PageSize + 1;
            var dict = new Dictionary<int, IEnumerable<PageMetadata>>();
            for (int i = 0; i < pageCount; i++)
            {
                var pages = allPages.Skip(i * PageSize).Take(PageSize);
                dict.Add(i + 1, pages.ToArray());
            }
            return dict;
        }
    }

}