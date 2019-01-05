using EtAndHkIde.Infrastructure;
using EtAndHkIde.ViewComponents;
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

        public PageListCardViewModel PageList { get; set; }

        public void OnGet()
        {
            var pages = _siteRepository.GetDraftPages();
            PageList = new PageListCardViewModel("Drafts", pages);
        }
    }
}