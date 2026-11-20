using EtAndHkIde.Archive;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Web.Pages.Archive
{
    // TODO refactor so SitePageModel isn't required
    public class IndexModel : PageModel
    {
        private readonly ArchiveService _archiveService;

        public IndexModel(ArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        public void OnGet()
        {
            var collections = _archiveService.GetCollections();
        }
    }
}
