using System.Collections.Generic;
using System.Threading.Tasks;
using EtAndHkIde.Infrastructure;
using EtAndHkIde.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageListViewComponent : ViewComponent
    {
        private readonly IContentsRepository _contentsRepository;

        public PageListViewComponent(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public IViewComponentResult Invoke(int recentCount = 0)
        {
            IEnumerable<ContentItem> pages;
            if (recentCount > 0)
            {
                pages = _contentsRepository.GetRecentPages(recentCount);
            }
            else
            {
                pages = _contentsRepository.GetPages();
            }

            return View(pages);
        }
    }
}