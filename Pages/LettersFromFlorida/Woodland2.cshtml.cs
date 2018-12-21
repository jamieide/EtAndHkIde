using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class Woodland2Model : PageModel, IContent
    {
        public string Title => "Woodland 2";
        public string Description => "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.";
        public DateTime? PublishDate => new DateTime(2018, 12, 14);
    }

}