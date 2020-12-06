using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class VermontMillingDynastyModel : SitePageModel
    {
        public VermontMillingDynastyModel() : base("A Vermont Milling Dynasty")
        {
            Description = "An article from the September 1958 issue of Eastern Feed Merchant.";
            PublishDate = new DateTime(2018, 12, 17);
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
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/VermontMillingDynasty/A-Vermont-Milling-Dynasty.pdf");
        }
    }
}