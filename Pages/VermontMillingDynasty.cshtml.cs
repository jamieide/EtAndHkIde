using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class VermontMillingDynastyModel : SitePageModel
    {
        public VermontMillingDynastyModel() : base()
        {
            Metadata = new PageMetadata
            {
                Title = "A Vermont Milling Dynasty",
                Description = "An article from the September 1958 issue of Eastern Feed Merchant.",
                PublishDate = new DateTime(2018, 12, 17),
                PreviewImage = "pages/VermontMillingDynasty/vermont-milling-dynasty-preview.jpg",
                PreviewQuote = "Determination and resourcefulness best describe the Ide philosophy for building and maintaining a good business. Going was not always easy.",
                Tags = new[]
                {
                    TagValues.People.TimothyIde,
                    TagValues.People.JacobIde,
                    TagValues.People.ElmoreIde,
                    TagValues.People.HoraceIde,
                    TagValues.People.WilliamIde,
                    TagValues.People.RichardIde,
                    TagValues.Places.Passumpsic,
                    TagValues.Places.StJohnsbury
                },
                Citation = new Citation(CitationType.Pdf, @"/pages/VermontMillingDynasty/A-Vermont-Milling-Dynasty.pdf"),
            };
        }
    }
}