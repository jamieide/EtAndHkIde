using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class VermontMillingDynastyModel : PageModel, IContent
    {
        public string Title => "A Vermont Milling Dynasty";
        public string Description => "An article from the September 1958 issue of Eastern Feed Merchant.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}