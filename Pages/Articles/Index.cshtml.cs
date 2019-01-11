using System.Collections.Generic;
using System.Linq;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.Articles
{
    public class ArticlesModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public ArticlesModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> Articles { get; set; }

        public void OnGet()
        {
            Articles = _siteRepository.GetPages("/Articles")
                .OrderByDescending(x => x.PublishDate);
        }
    }
}