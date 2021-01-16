using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Infrastructure
{
    public abstract class SitePageModel : PageModel
    {
        public PageMetadata Metadata { get; protected set; }
    }

}