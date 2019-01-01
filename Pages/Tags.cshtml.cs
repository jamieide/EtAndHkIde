using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages
{
    public class TagsModel : PageModel
    {
        private readonly IMetadataRepository _metadataRepository;

        public TagsModel(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }


        public IDictionary<TagType, IEnumerable<Tag>> TagsByType { get; set; }
        public IDictionary<Tag, IEnumerable<PageMetadata>> PagesByTag { get; set; }

        public void OnGet()
        {
            TagsByType = _metadataRepository.GetTags()
                .GroupBy(x => x.TagType)
                .ToDictionary(k => k.Key, v => v.Select(x => x));

            PagesByTag = (from p in _metadataRepository.GetPageMetadatas(null)
                          from t in p.Tags
                          select new
                          {
                              Page = p,
                              Tag = t
                          }).GroupBy(k => k.Tag)
                .ToDictionary(k => k.Key, v => v.Select(x => x.Page));
        }
    }
}