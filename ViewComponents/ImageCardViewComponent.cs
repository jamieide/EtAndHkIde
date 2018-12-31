using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCardViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMetadataRepository _metadataRepository;

        public ImageCardViewComponent(IHttpContextAccessor httpContextAccessor, IMetadataRepository metadataRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _metadataRepository = metadataRepository;
        }

        public IViewComponentResult Invoke(string name)
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var image = _metadataRepository.GetImage(path, name);
            return View(image);
        }
    }
}