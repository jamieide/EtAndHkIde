using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public abstract class SitePageModel : PageModel
    {
        protected SitePageModel()
        {
            var fullName = GetType().FullName;
            var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
            var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
            Path = fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
        }

        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? PublishDate { get; set; }
        public bool IsHighlight { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
        public Citation Citation { get; set; }
        public IEnumerable<SitePageModel> RelatedSitePageModels { get; set; } = new List<SitePageModel>();

        public string Path { get; }
    }

}