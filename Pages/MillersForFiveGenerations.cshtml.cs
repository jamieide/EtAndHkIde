using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class MillersForFiveGenerationsModel : PageModel, IContentPage
    {
        public string Title => "Millers For Five Generations";
        public string Description => "A booklet published in 1953 on the occasion of the company's 140th anniversary.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}