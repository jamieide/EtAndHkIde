using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class LargeFire1883Model : SitePageModel
    {
        public LargeFire1883Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Large Fire",
                Description = "A newspaper article describing the fire that consumed the original Passumpsic mill in 1883.",
                PublishDate = new DateTime(2018, 12, 21),
                PreviewQuote = "The dam was placed there by the one who put rocks into the earth, and gave 23 foot head before it was raised by the hand of man.",
                Tags = new[] { TagValues.Places.Passumpsic }
            };
        }
    }
}