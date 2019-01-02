using System.Collections.Generic;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.ViewComponents
{
    public class PageListCardViewModel
    {
        public PageListCardViewModel(string title, IEnumerable<PageMetadata> pages)
        {
            Title = title;
            Pages = pages;
        }

        public PageListCardViewModel(IEnumerable<PageMetadata> pages)
        {
            Pages = pages;
        }

        public string Title { get; set; }
        public IEnumerable<PageMetadata> Pages { get; set; }
    }
}