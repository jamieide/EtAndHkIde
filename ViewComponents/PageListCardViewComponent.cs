using System.Linq;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageListCardViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public PageListCardViewComponent(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(string title, int? count, bool isFeatured)
        {
            var pages = _siteRepository.GetPages("/Articles");
            if (isFeatured)
            {
                pages = pages.Where(x => x.Tags.Contains(TagValues.Featured));
            }
            if (count.HasValue)
            {
                pages = pages.Take(count.Value);
            }
            var vm = new PageListCardViewModel(title, pages);
            return View(vm);
        }
    }
}