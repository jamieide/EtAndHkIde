using EtAndHkIde.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCollectionCardViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public ImageCollectionCardViewComponent(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(string name)
        {
            // todo add class (card-group etc) to args and ViewData(?)
            var imageCollection = _siteRepository.GetImageCollection(name);
            return View(imageCollection);
        }
    }
}