using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles.LettersFromFlorida
{
    public class SavannahModel : SitePageModel
    {
        public SavannahModel() : base("Savannah")
        {
            Description = "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.";
            PublishDate = new DateTime(2018, 12, 14); ;
        }
    }
}