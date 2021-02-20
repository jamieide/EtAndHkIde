using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class VhsPassumpsicPhotosModel : SitePageModel
    {
        public VhsPassumpsicPhotosModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Vermont Historical Society Photos",
                Description = "In 2018, the Vermont Historical Society acquired several cabinet card photographs from a descendant of Francis \"Frank\" Mason.",
                PublishDate = new DateTime(2021, 1, 18),
                PreviewImage = "pages/VhsPassumpsicPhotos/vhspassumpsicphotos-preview.jpg"
            };
        }
    }
}
