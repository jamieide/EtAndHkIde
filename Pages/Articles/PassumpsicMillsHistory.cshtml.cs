using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class PassumpsicMillsHistoryModel : SitePageModel
    {
        public PassumpsicMillsHistoryModel() : base("Passumpsic Mills History")
        {
            Description = "A brief history of the Passumpsic Mills";
            Tags = new[] { TagValues.Places.Passumpsic };
        }
    }
}