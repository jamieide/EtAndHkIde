using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IMetadataRepository
    {
        //todo return collection types?
        IEnumerable<PageMetadata> GetPageMetadatas(int? count);
        IEnumerable<PageMetadata> GetHighlightPageMetadatas(int? count);
        IEnumerable<PageMetadata> GetPageMetadatasForTag(Tag tag);

        PageMetadata GetPageMetadata(string path);

        IEnumerable<FileMetadata> GetImages(string path);
        FileMetadata GetImage(string path, string name);

        IEnumerable<Tag> GetTags();
    }
}