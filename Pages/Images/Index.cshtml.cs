using System.Collections.Generic;
using System.Linq;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public IndexModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> Images { get; set; }

        public void OnGet()
        {
            Images = _siteRepository.GetPages("/Images")
                .OrderByDescending(x => x.PublishDate);
        }
    }
}