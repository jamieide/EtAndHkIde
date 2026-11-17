using EtAndHkIde.Web.Infrastructure;
using System;

namespace EtAndHkIde.Web.Pages
{
    public class VhsPassumpsicPhotosModel : SitePageModel
    {
        public VhsPassumpsicPhotosModel() { }
        public override void DefineMetadata()
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
