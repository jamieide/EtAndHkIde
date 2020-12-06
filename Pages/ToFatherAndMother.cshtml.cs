using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class ToFatherAndMotherModel : SitePageModel
    {
        public ToFatherAndMotherModel() : base("To Father and Mother from Their Girls")
        {
            Description = "A 50th anniversary gift from the daughters of Elmore and Cynthia Ide, Katharine, Mary Ellen and Fanny. Illustrated by Fanny Ide.";
            PublishDate = new DateTime(2019, 1, 12);
            PreviewQuote = "";
            PreviewImage = "articles/ToFatherAndMother/to-father-and-mother-009.jpg";
            Citation = new Citation(CitationType.Pdf, @"/articles/ToFatherAndMother/To Father And Mother.pdf");
            Tags = new[] { TagValues.System.Featured, TagValues.People.ElmoreIde, TagValues.People.CynthiaIde };
        }
    }
}