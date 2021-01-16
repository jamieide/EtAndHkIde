using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class SavannahModel : SitePageModel
    {
        public SavannahModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Savannah",
                Description = "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.",
                PublishDate = new DateTime(2018, 12, 14)
            };
        }
    }
}