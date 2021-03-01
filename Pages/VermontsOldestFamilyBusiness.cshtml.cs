using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class VermontsOldestFamilyBusinessModel : SitePageModel
    {
        public VermontsOldestFamilyBusinessModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Vermont's Oldest Family Business",
                Description = "A wonderfully written and lavishly illustrated booklet celebrating the 175th anniversary of the business. The oldest family owned and operated feed business in the United States, serving the Upper Connecticut Valley for six generations.",
                PublishDate = new DateTime(2021, 2, 27),
                PreviewImage = "pages/VermontsOldestFamilyBusiness/vofb-preview.jpg",
                PreviewQuote = "The mill stones were made from local granite. In accordance with an age old custom, the miller was paid in part with a percentage (toll) of the grain he milled. Timothy Ide's toll was a sixteenth part, or two quarts of every bushel he milled.",
                Citation = new Citation(CitationType.Pdf, "pages/VermontsOldestFamilyBusiness/Vermont's Oldest Family Business.pdf"),
                Tags = new[]
                {
                    TagValues.System.Featured,
                    TagValues.People.TimothyIde,
                    TagValues.People.JacobIde,
                    TagValues.People.ElmoreIde,
                    TagValues.People.HoraceIde,
                    TagValues.People.WilliamIde,
                    TagValues.People.RichardIde,
                    TagValues.People.TimIde,
                    TagValues.People.RobertIde,
                    TagValues.People.MaitlandBean,
                    TagValues.People.GeorgeGray,
                    TagValues.Places.Passumpsic,
                    TagValues.Places.StJohnsbury
                },
            };
        }
    }
}
