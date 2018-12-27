using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class Woodland3Model : PageModel, IContentPage
    {
        public string Title => "Woodland 3";
        public string Description => "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.";
        public DateTime? PublishDate => new DateTime(2018, 12, 14);
    }

}