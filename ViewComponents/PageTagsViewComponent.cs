using System.Linq;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageTagsViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMetadataRepository _metadataRepository;

        public PageTagsViewComponent(IHttpContextAccessor httpContextAccessor, IMetadataRepository metadataRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _metadataRepository = metadataRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var pageMetadata = _metadataRepository.GetPageMetadata(path);
            var tags = pageMetadata?.Tags.OrderBy(x => x.TagType.Name) ?? Enumerable.Empty<Tag>();
            return View(tags);
        }
    }
}