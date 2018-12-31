using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Infrastructure
{
    public class SitePageModel : PageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsHighlight { get; set; }
    }
}