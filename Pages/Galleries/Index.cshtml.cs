using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages.Galleries
{
    public class IndexModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public IndexModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> Galleries { get; set; }

        public void OnGet()
        {
            Galleries = _siteRepository.GetPages("/Galleries")
                .OrderByDescending(x => x.PublishDate);
        }
    }
}