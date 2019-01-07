using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    public abstract class SitePageModel : PageModel
    {
        protected SitePageModel(string title)
        {
            Title = title;
        }

        public string Title { get; }
        public string Description { get; set; } = "";
        public DateTime? PublishDate { get; set; }

        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
        public Citation Citation { get; set; }
    }

}