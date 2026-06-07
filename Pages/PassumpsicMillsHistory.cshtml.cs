using EtAndHkIde.Web.Infrastructure;

namespace EtAndHkIde.Web.Pages
{
    public class PassumpsicMillsHistoryModel : SitePageModel
    {
        public PassumpsicMillsHistoryModel() { }
        public override void DefineMetadata()
        {
            Metadata = new PageMetadata
            {
                Title = "Passumpsic Mills History",
                Description = "A brief history of the Passumpsic Mills",
                Tags = new[] { TagValues.Places.Passumpsic }
            };
        }
    }
}