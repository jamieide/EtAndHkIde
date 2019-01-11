using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages
{
    public class TagsModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public TagsModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public string[] Tags { get; set; }
        public IDictionary<string, IEnumerable<PageMetadata>> PagesByTag { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Tag { get; set; }

        public void OnGet()
        {
            Tags = _siteRepository.GetTags().ToArray();
            PagesByTag = _siteRepository.GetPagesByTag();
        }
    }
}