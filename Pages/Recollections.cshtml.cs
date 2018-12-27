using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class RecollectionsModel : PageModel, IContentPage
    {
        public string Title => "Recollections";
        public string Description => "William Adams Ide's Recollections, compiled and published in 1951.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}