using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageListCardViewComponent : ViewComponent
    {
        private readonly IContentsRepository _contentsRepository;

        public PageListCardViewComponent(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public IViewComponentResult Invoke(string title, int? count, bool highlights)
        {
            var pages = highlights ? _contentsRepository.GetHighlightPages(count) : _contentsRepository.GetPages(count);
            var vm = new PageListCardViewModel()
            {
                Title = title,
                Pages = pages
            };
            return View(vm);
        }
    }
}