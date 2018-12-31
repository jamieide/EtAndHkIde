using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class SavannahModel : SitePageModel
    {
        public SavannahModel()
        {
            Title = "Savannah";
            Description = "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.";
            PublishDate = new DateTime(2018, 12, 14); ;
        }
    }
}