using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages
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