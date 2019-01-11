using System.Collections.Generic;
using System.Linq;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.Blog
{
    public class BlogModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public BlogModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<PageMetadata> BlogEntries { get; set; }

        public void OnGet()
        {
            BlogEntries = _siteRepository.GetPages("/Blog")
                .OrderByDescending(x => x.PublishDate);
        }
    }
}