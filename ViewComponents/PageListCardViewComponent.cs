using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EtAndHkIde.ViewComponents
{
    public class PageListCardViewComponent : ViewComponent
    {
        private readonly IMetadataRepository _metadataRepository;

        public PageListCardViewComponent(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        public IViewComponentResult Invoke(string title, int? count, bool highlights)
        {
            var pages = highlights ? _metadataRepository.GetHighlightPageMetadatas(count) : _metadataRepository.GetPageMetadatas(count);
            var vm = new PageListCardViewModel()
            {
                Title = title,
                Pages = pages
            };
            return View(vm);
        }
    }
}