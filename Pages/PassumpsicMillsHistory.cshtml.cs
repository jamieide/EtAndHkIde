using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class PassumpsicMillsHistoryModel : SitePageModel
    {
        public PassumpsicMillsHistoryModel()
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