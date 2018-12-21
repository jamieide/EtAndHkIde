using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class RandallArmorPhotosModel : PageModel, IContent
    {
        public string Title => "Randall Armor Photographs";
        public string Description => "A series of photographs of the St. Johnsbury mill taken by Randall Armor on New Year's Eve 2010.";
        public DateTime? PublishDate => new DateTime(2018, 12, 15);
    }
}