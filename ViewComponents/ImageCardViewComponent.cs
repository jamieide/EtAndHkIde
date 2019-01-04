using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCardViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISiteRepository _siteRepository;

        public ImageCardViewComponent(IHttpContextAccessor httpContextAccessor, ISiteRepository siteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(string name)
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var image = _siteRepository.GetImage(path, name);
            return View(image);
        }
    }
}