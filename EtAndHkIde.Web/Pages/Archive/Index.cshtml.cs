using EtAndHkIde.Archive.Models;
using EtAndHkIde.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtAndHkIde.Web.Pages.Archive
{
    public class IndexModel(ArchiveService archiveService) : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            Collections = await archiveService.GetSubCollections("NJVGILN7");
            return Page();
        }

        public List<Collection> Collections { get; set; }
    }
}
