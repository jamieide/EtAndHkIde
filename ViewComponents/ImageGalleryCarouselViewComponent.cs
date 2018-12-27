using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{

    public class ImageGalleryCarouselViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContentsRepository _contentsRepository;

        public ImageGalleryCarouselViewComponent(IHttpContextAccessor httpContextAccessor, IContentsRepository contentsRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _contentsRepository = contentsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var images = _contentsRepository.GetImages(path);
            return View(images);
        }
    }
}