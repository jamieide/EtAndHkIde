using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class ToFatherAndMotherModel : SitePageModel
    {
        public ToFatherAndMotherModel() : base("To Father and Mother from Their Girls")
        {
            Citation = new Citation(CitationType.Pdf, @"/articles/ToFatherAndMother/To Father And Mother.pdf");
            Tags = new[] { TagValues.Featured };
        }
    }
}