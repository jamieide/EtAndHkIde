using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class RichardIdeWorldWar2PhotosModel : SitePageModel
    {
        public RichardIdeWorldWar2PhotosModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Richard Ide World War II Photos",
                Description = "A collection of snapshots taken by Richard Ide during World War II service. Most and maybe all these photos were taken in Bremen.",
                PublishDate = new DateTime(2019, 1, 12),
                PreviewImage = "pages/RichardIdeWorldWar2/Richard Ide WW2 preview.jpg",
                Tags = new[] { TagValues.System.Photos, TagValues.People.RichardIde }
            };
        }
    }
}