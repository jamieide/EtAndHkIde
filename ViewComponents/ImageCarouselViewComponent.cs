using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{

    public class ImageCarouselViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public ImageCarouselViewComponent(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(string path)
        {
            var images = _siteRepository.GetImages(path);
            return View(images);
        }
    }
}