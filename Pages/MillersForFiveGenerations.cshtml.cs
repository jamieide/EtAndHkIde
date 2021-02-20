using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class MillersForFiveGenerationsModel : SitePageModel
    {
        public MillersForFiveGenerationsModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Millers For Five Generations",
                Description = "A booklet published in 1953 on the occasion of the company's 140th anniversary.",
                PublishDate = new DateTime(2018, 12, 17),
                UpdatedDate = new DateTime(2020, 2, 20),
                PreviewQuote = "This mill, built about 1789, was the first of several mills that have carried on a tradition of grain and milling for the Ide family through five generations and the trials and triumphs of 140 years of business.",
                Tags = new[]
            {
                TagValues.System.Featured,
                TagValues.People.TimothyIde,
                TagValues.People.JacobIde,
                TagValues.People.ElmoreIde,
                TagValues.People.WilliamIde,
                TagValues.People.RichardIde,
                TagValues.Places.Passumpsic,
                TagValues.Places.StJohnsbury
            },
                Citation = new Citation(CitationType.Pdf, @"/pages/MillersForFiveGenerations/Millers For Five Generations-compressed.pdf")
            };
        }
    }
}