using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class PassumpsicMillPhotosModel : PageModel, IContent
    {
        public string Title => "Passumpsic Mill Photos";
        public string Description => "A collection of photographs of the original and rebuilt mills in Passumpsic";
        public DateTime? PublishDate => new DateTime(2018, 12, 16);
    }
}