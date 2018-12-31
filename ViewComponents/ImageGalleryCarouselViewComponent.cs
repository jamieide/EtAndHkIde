using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{

    public class ImageGalleryCarouselViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMetadataRepository _metadataRepository;

        public ImageGalleryCarouselViewComponent(IHttpContextAccessor httpContextAccessor, IMetadataRepository metadataRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _metadataRepository = metadataRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var images = _metadataRepository.GetImages(path);
            return View(images);
        }
    }
}