using EtAndHkIde.Archive.Models;
using EtAndHkIde.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtAndHkIde.Web.Pages.Archive
{
    public class CollectionModel(ArchiveService archiveService) : PageModel
    {
        private readonly ArchiveService _archiveService = archiveService;

        public async Task<IActionResult> OnGet(string key)
        {
            Items = await _archiveService.GetItemsByCollection(key);
            return Page();
        }

        public List<Item> Items { get; set; }
    }
}
