using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Infrastructure
{
    public abstract class ContentPageModel : PageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}