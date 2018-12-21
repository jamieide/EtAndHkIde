using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EtAndHkIde.Pages
{
    public class MillersForACenturyModel : PageModel, IContent
    {
        public string Title => "Millers For A Century";
        public string Description => "A long newspaper article from The Caledonian published on the occasion of the 100th anniversary in 1913";
        public DateTime? PublishDate => new DateTime(2018, 12, 19);
    }
}