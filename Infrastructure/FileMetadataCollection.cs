using System;
using System.Collections.ObjectModel;

namespace EtAndHkIde.Infrastructure
{
    public class FileMetadataCollection : KeyedCollection<string, FileMetadata>
    {
        public FileMetadataCollection() : base(StringComparer.OrdinalIgnoreCase)
        { }

        protected override string GetKeyForItem(FileMetadata item)
        {
            return item.Path;
        }
    }
}