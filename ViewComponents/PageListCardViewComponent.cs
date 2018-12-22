using System.Collections.Generic;
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
            IEnumerable<ContentItem> pages;
            if (highlights)
            {
                pages = _contentsRepository.GetHighlightPages(count);
            }
            else
            {
                pages = _contentsRepository.GetPages(count);
            }
            var vm = new PageListCardViewModel()
            {
                Title = title,
                Pages = pages
            };
            return View(vm);
        }
    }
}