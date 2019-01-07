using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.Articles
{
    public class LightingTheVillageModel : SitePageModel
    {
        public LightingTheVillageModel() : base("Lighting the Village")
        {
            Description = "This post describes the electrification of St. Johnsbury streets in 1889, and a proposal by E. T. & H. K. Ide to install and power the lights from the water power in Passumpsic.";
            PublishDate = new DateTime(2019, 1, 4);
            Tags = new[] { TagValues.ElmoreIde, TagValues.Passumpsic, TagValues.StJohnsbury };
        }
    }
}