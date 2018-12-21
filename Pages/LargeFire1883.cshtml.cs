using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class LargeFire1883Model : PageModel, IContent
    {
        public string Title => "Large Fire 1883";
        public string Description => "A newspaper article describing the fire that consumed the original Passumpsic mill in 1883";
        public DateTime? PublishDate => new DateTime(2018, 12, 21);
    }
}