using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class LargeFire1883Model : SitePageModel
    {
        public LargeFire1883Model()
        {
            Title = "Large Fire 1883";
            Description = "A newspaper article describing the fire that consumed the original Passumpsic mill in 1883";
            PublishDate = new DateTime(2018, 12, 21);
            Tags = new[] { Tag.Passumpsic };
        }
    }
}