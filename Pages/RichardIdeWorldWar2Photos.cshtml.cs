using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class RichardIdeWorldWar2PhotosModel : SitePageModel
    {
        public RichardIdeWorldWar2PhotosModel() : base("Richard Ide World War II Photos")
        {
            Description = "A collection of snapshots taken by Richard Ide during World War II service. Most and maybe all these photos were taken in Bremen.";
            PublishDate = new DateTime(2019, 1, 12);
            Tags = new[] { TagValues.People.RichardIde };
        }
    }
}