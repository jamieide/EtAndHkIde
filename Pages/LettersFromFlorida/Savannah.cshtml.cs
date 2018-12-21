using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class SavannahModel : PageModel, IContent
    {
        public string Title => "Savannah";
        public string Description => "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.";
        public DateTime? PublishDate => new DateTime(2018, 12, 14);
    }
}