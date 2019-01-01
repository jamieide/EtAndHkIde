using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EtAndHkIde.Pages
{
    public class TagsModel : PageModel
    {
        private readonly IMetadataRepository _metadataRepository;

        public TagsModel(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        public IEnumerable<Tag> Tags { get; set; }
        public IDictionary<Tag, IEnumerable<PageMetadata>> PagesByTag { get; set; }

        public void OnGet()
        {
            Tags = _metadataRepository.GetTags();
            PagesByTag = _metadataRepository.GetPagesByTag();
        }
    }
}