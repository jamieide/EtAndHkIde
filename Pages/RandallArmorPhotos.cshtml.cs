using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class RandallArmorPhotosModel : SitePageModel
    {
        public RandallArmorPhotosModel()
        {
            Title = "Randall Armor Photographs";
            Description = "A series of photographs of the St. Johnsbury mill taken by Randall Armor on New Year's Eve 2010.";
            PublishDate = new DateTime(2018, 12, 15);
        }
    }
}