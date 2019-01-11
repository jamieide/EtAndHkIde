using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Images
{
    public class RandallArmorPhotosModel : SitePageModel
    {
        public RandallArmorPhotosModel() : base("Randall Armor Photographs")
        {
            Description = "A series of photographs of the St. Johnsbury mill taken by Randall Armor on New Year's Eve 2010.";
            PublishDate = new DateTime(2018, 12, 15);
            Tags = new[] { TagValues.StJohnsbury };
            Citation = new Citation(CitationType.Website, @"http://www.armorfoto.com", "Photographs courtesy of Randall Armor &copy;2013");
        }
    }
}