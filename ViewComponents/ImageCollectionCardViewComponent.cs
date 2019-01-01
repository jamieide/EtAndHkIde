using System;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    [Obsolete("will be back")]
    public class ImageCollectionCardViewComponent : ViewComponent
    {
        //private readonly ISiteRepository _siteRepository;

        //public ImageCollectionCardViewComponent(ISiteRepository siteRepository)
        //{
        //    _siteRepository = siteRepository;
        //}

        public IViewComponentResult Invoke(string name)
        {
            throw new NotImplementedException();
            //// todo add class (card-group etc) to args and ViewData(?)
            //var imageCollection = _siteRepository.GetImageCollection(name);
            //return View(imageCollection);
        }
    }
}