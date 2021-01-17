using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public IndexModel(ISiteRepository siteRepository, IWebHostEnvironment webHostEnvironment)
        {
            _siteRepository = siteRepository;
            IsDevelopment = webHostEnvironment.IsDevelopment();
        }

        public const int PageSize = 8;

        public bool IsDevelopment { get; set; }
        public IEnumerable<PageMetadata> RecentPages { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> FeaturePages { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> PhotoPages { get; set; }
        public IDictionary<int, IEnumerable<PageMetadata>> AllPages { get; set; }

        public void OnGet()
        {
            var allPages = _siteRepository.GetPages()
                .OrderByDescending(x => x.PublishDate);
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