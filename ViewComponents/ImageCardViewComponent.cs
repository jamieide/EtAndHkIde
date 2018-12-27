using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class ImageCardViewComponent : ViewComponent
    {
        private readonly IContentsRepository _contentsRepository;

        public ImageCardViewComponent(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public IViewComponentResult Invoke(string path)
        {
            var image = _contentsRepository.GetImage(path);
            return View(image);
        }
    }
}