using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISiteRepository _siteRepository;

        public SidebarViewComponent(IHttpContextAccessor httpContextAccessor, ISiteRepository siteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var page = _siteRepository.GetPage(path);
            return View(page);
        }
    }
}