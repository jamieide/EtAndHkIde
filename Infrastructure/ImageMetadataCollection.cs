using System;
using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class ImageMetadataCollection : KeyedCollection<string, ImageMetadata>
    {
        public ImageMetadataCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override string GetKeyForItem(ImageMetadata item)
        {
            return item.Path;
        }
    }
}