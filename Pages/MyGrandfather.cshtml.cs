using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class MyGrandfatherModel : SitePageModel
    {
        public MyGrandfatherModel() : base("My Grandfather")
        {
            Description = "The author of this biographical sketch of E. T. Ide, possibly a school project, is unknown but it may be Katherine Ide Sprague. Katherine was the daughter of Fanny Knights and Oliver Mitchell Wentworth Sprague. She was born in Tokyo, Japan, and lived in Cambridge, Massachusetts as a girl.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[] { TagValues.People.ElmoreIde };
            Citation = new Citation(CitationType.Pdf, @"/content/MyGrandfather/My-Grandfather-A-Biographical-Sketch.pdf");
        }
    }
}