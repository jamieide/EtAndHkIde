using EtAndHkIde.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCollectionCarouselViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public ImageCollectionCarouselViewComponent(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(string name)
        {
            var imageCollection = _siteRepository.GetImageCollection(name);
            return View(imageCollection);
        }
    }
}