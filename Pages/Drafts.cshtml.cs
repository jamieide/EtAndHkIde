using System.Collections.Generic;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class DraftsModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public DraftsModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> Drafts { get; set; }

        public void OnGet()
        {
            Drafts = _siteRepository.GetDraftPages();
        }
    }
}