using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class InMemoryOfCompanionHoraceKnightIdeModel : SitePageModel
    {
        public InMemoryOfCompanionHoraceKnightIdeModel() : base()
        {
            Metadata = new PageMetadata
            {
                Title = "In Memory Of Companion Horace Knight Ide",
                Description = "A memorial to H. K. Ide published by the Military Order of the Loyal Legion of the United States in 1897.",
                PublishDate = new DateTime(2018, 12, 17),
                PreviewQuote = "He was nearly four years in the service, was twice wounded, was twice a prisoner of war, and participated&mdash,it is believed&mdash,in forty-two battles and skirmishes.",
                Tags = new[] { TagValues.People.HoraceIde },
                Citation = new Citation(CitationType.Pdf, @"/pages/InMemoryOfCompanionHoraceKnightIde/MOLLUS-Circular-No.-3-Series-of-1897.pdf")
            };
        }
    }
}