using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Infrastructure
{
    public abstract class SitePageModel : PageModel
    {
        public PageMetadata Metadata { get; protected set; }

        /// <summary>
        /// Call base.OnGet to set ViewData.
        /// </summary>
        public virtual void OnGet()
        {
            ViewData["Title"] = Metadata.Title;
            ViewData["Description"] = Metadata.Description;
            ViewData["Tags"] = string.Join(',', Metadata.Tags);
        }
    }

}