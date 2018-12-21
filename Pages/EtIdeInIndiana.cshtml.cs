using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class EtIdeInIndianaModel : PageModel, IContent
    {
        public string Title => "E. T. Ide in Indiana";
        public string Description => "A letter from E. T. to American Miller in Feb. 1914 describing the time he spent learning the milling trade in Indiana in 1865.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}
