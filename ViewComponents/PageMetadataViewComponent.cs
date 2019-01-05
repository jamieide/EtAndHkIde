using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.ViewComponents
{
    public class PageMetadataViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISiteRepository _siteRepository;

        public PageMetadataViewComponent(IHttpContextAccessor httpContextAccessor, ISiteRepository siteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteRepository = siteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path;
            var page = _siteRepository.GetPage(path);
            var relatedPages = new List<PageMetadata>();
            if (page.RelatedPagePaths != null)
            {
                foreach (var relatedPagePath in page.RelatedPagePaths)
                {
                    var relatedPage = _siteRepository.GetPage(relatedPagePath);
                    if (relatedPage != null)
                    {
                        relatedPages.Add(relatedPage);
                    }
                }
            }
            var vm = new PageMetadataViewModel()
            {
                Page = page,
                RelatedPages = relatedPages
            };

            return View(vm);
        }
    }
}