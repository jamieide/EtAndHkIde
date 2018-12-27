using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class ContentsModel : PageModel
    {
        private readonly IContentsRepository _contentsRepository;

        public ContentsModel(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public ContentPageCollection ContentPages { get; set; }

        public void OnGet()
        {
            ContentPages = _contentsRepository.GetContentPages();
        }
    }
}