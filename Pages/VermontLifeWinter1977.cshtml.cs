using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EtAndHkIde.Pages
{
    public class VermontLifeWinter1977Model : PageModel, IContent
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime? PublishDate { get; }
    }
}