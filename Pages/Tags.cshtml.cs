using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.Pages
{
    public class TagsModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public TagsModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IEnumerable<Tag> Tags { get; set; }
        public IDictionary<Tag, IEnumerable<PageMetadata>> PagesByTag { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Tag { get; set; }

        public void OnGet()
        {
            Tags = _siteRepository.GetTags();
            PagesByTag = _siteRepository.GetPagesByTag();
        }
    }
}