using System;
using EtAndHkIde.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    [Obsolete("will be back")]

    public class ImageCollectionCarouselViewComponent : ViewComponent
    {
        //private readonly ISiteRepository _siteRepository;

        //public ImageCollectionCarouselViewComponent(ISiteRepository siteRepository)
        //{
        //    _siteRepository = siteRepository;
        //}

        public IViewComponentResult Invoke(string name)
        {
            throw new NotImplementedException();
            //var imageCollection = _siteRepository.GetImageCollection(name);
            //return View(imageCollection);
        }
    }
}