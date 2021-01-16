using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class LightingTheVillageModel : SitePageModel
    {
        public LightingTheVillageModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Lighting the Village",
                Description = "This post describes the electrification of St. Johnsbury streets in 1889, and a proposal by E. T. & H. K. Ide to install and power the lights from the water power in Passumpsic.",
                PublishDate = new DateTime(2019, 1, 4),
                PreviewQuote = "The Ides have owned a valuable water power at Passumpsic for the last 75 years or more. The present firm have owned it for 22 years.",
                Tags = new[] { TagValues.People.ElmoreIde, TagValues.Places.Passumpsic, TagValues.Places.StJohnsbury }
            };
        }
    }
}