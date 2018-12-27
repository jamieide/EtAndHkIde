using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class InMemoryOfCompanionHoraceKnightIdeModel : PageModel, IContentPage
    {
        public string Title => "In Memory Of Companion Horace Knight Ide";
        public string Description => "A memorial to H. K. Ide published by the Military Order of the Loyal Legion of the United States in 1897.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}