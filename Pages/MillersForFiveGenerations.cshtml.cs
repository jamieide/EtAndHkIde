using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class MillersForFiveGenerationsModel : SitePageModel
    {
        public MillersForFiveGenerationsModel() : base("Millers For Five Generations")
        {
            Description = "A booklet published in 1953 on the occasion of the company's 140th anniversary.";
            PublishDate = new DateTime(2018, 12, 17);
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
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/MillersForFiveGenerations/Millers-for-Five-Generations.pdf");
        }
    }
}