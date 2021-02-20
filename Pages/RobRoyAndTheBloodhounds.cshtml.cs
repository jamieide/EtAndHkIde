using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class RobRoyAndTheBloodhoundsModel : SitePageModel
    {
        public RobRoyAndTheBloodhoundsModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Rob Roy and the Bloodhounds",
                Description = "Rambling reminisces about growing up in St. Johnsbury written by Angus Brooks in 1985.",
                PreviewQuote = "The following pages involve a number of people but specifically four boys [Angus Brooks, Dick Ide, Bill Ricker, and Bill Sprague] in St. Johnsbury, Vermont, during the 1920-1940 days through grade school, the Academy and later years.",
                Citation = new Citation(CitationType.Pdf, "pages/RobRoyAndTheBloodhounds/Rob Roy and the Bloodhounds.pdf"),
                PublishDate = new DateTime(2021, 1, 31)
            };
        }
    }
}
