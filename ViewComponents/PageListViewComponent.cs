using System.Collections.Generic;
using System.Threading.Tasks;
using EtAndHkIde.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageListViewComponent : ViewComponent
    {
        private readonly ISiteRepository _siteRepository;

        public PageListViewComponent(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke(int recentCount = 0)
        {
            IEnumerable<Page> pages;
            if (recentCount > 0)
            {
                pages = _siteRepository.GetRecentPages(recentCount);
            }
            else
            {
                pages = _siteRepository.GetPages();
            }

            return View(pages);
        }
    }
}