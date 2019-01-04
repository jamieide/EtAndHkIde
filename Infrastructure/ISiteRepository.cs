using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface ISiteRepository
    {
        /// <summary>
        /// Get published pages sorted by publish date descending.
        /// </summary>
        IEnumerable<PageMetadata> GetPages();

        /// <summary>
        /// Get draft (null publish date) pages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<PageMetadata> GetDraftPages();

        PageMetadata GetPage(string path);


        IDictionary<Tag, IEnumerable<PageMetadata>> GetPagesByTag();

        IEnumerable<FileMetadata> GetImages(string path);
        FileMetadata GetImage(string path, string name);

        IEnumerable<TagType> GetTagTypes();
        IEnumerable<Tag> GetTags();
    }
}