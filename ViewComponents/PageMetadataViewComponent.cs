using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageMetadataViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISiteRepository _siteRepository;

        public PageMetadataViewComponent(IHttpContextAccessor httpContextAccessor, ISiteRepository siteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var pageMetadata = _siteRepository.GetPage(path);
            return View(pageMetadata);
        }
    }
}