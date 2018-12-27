using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class MyGrandfatherModel : PageModel, IContentPage
    {
        public string Title => "My Grandfather";
        public string Description => "A biographical sketch of Elmore T. Ide.";
        public DateTime? PublishDate => new DateTime(2018, 12, 17);
    }
}