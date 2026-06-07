using EtAndHkIde.Web.Infrastructure;
using System;

namespace EtAndHkIde.Web.Pages
{
    public class AdamsFelchTaylorIdeModel : SitePageModel
    {
        public AdamsFelchTaylorIdeModel()
        {
        }
        public override void DefineMetadata()
        {
            Metadata = new PageMetadata
            {
                Title = "William Adams, Henry Felch, John Taylor, Nicholas Ide",
                Description = "Short biographical and genealogical sketches of the Adams, Felch, Taylor and Ide families.",
                PublishDate = new DateTime(2021, 1, 19),
                PreviewQuote = "Just a few facts, which we may be glad to remember...",
                Citation = new Citation(CitationType.Pdf, @"/pages/AdamsFelchTaylorIde/William Adams Henry Felch John Taylor Nicholas Ide.pdf")
            };
        }
    }
}
