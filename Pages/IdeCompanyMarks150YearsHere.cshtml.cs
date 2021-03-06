using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class IdeCompanyMarks150YearsHereModel : SitePageModel
    {
        public IdeCompanyMarks150YearsHereModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Ide Company Marks 150 Years Here",
                PublishDate = new DateTime(2021, 3, 6),
                Description = "An article from the Caledonian-Record on December 21, 1963 on the occasion of the 150th anniversary of E. T. & H. K. Ide. This edition is not available online, fortunately I have five yellowed copies to choose from.",
                PreviewQuote = "A century and a half, four buildings an six generations have contributed to the success of E. T. & H. K. Ide, Inc.",
                Tags = new[] { TagValues.Places.StJohnsbury, TagValues.People.RichardIde, TagValues.People.TimIde }
            };
        }
    }
}
