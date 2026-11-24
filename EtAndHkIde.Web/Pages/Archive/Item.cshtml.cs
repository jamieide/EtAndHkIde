using EtAndHkIde.Archive.Models;
using EtAndHkIde.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EtAndHkIde.Web.Pages.Archive
{
    public class ItemModel(ArchiveService archiveService) : PageModel
    {
        private readonly ArchiveService _archiveService = archiveService;

        public async Task<IActionResult> OnGet(string key)
        {
            Item = await _archiveService.GetItem(key);
            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        public Item Item { get; set; }
    }
}
