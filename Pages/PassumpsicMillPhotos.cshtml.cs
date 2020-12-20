﻿using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class PassumpsicMillPhotosModel : SitePageModel
    {
        public PassumpsicMillPhotosModel() : base("Passumpsic Mill Photos")
        {
            Description = "A collection of photographs of the original and rebuilt mills in Passumpsic";
            PublishDate = new DateTime(2018, 12, 16);
            Tags = new[] { TagValues.Places.Passumpsic };
        }
    }
}