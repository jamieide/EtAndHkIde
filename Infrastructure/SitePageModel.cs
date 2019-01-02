using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public abstract class SitePageModel : PageModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? PublishDate { get; set; }
        public bool IsHighlight { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
        public Citation Citation { get; set; }
    }
}