using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EtAndHkIde.Pages
{
    public class TagsModel : PageModel
    {
        private readonly ISiteRepository _siteRepository;

        public TagsModel(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IDictionary<string, IEnumerable<PageMetadata>> PagesByTag { get; set; }

        public void OnGet()
        {
            PagesByTag = new Dictionary<string, IEnumerable<PageMetadata>>();
            var tags = _siteRepository.GetTags();
            foreach (var tag in tags)
            {
                var pagesForTag = _siteRepository.GetPagesForTag(tag);
                PagesByTag.Add(tag, pagesForTag);
            }
        }
    }
}