using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCardViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContentsRepository _contentsRepository;

        public ImageCardViewComponent(IHttpContextAccessor httpContextAccessor, IContentsRepository contentsRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _contentsRepository = contentsRepository;
        }

        public IViewComponentResult Invoke(string name)
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var image = _contentsRepository.GetImage(path, name);
            return View(image);
        }
    }
}