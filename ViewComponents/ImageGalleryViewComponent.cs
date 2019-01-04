using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageGalleryViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public ImageGalleryViewComponent(ISiteRepository siteRepository)
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