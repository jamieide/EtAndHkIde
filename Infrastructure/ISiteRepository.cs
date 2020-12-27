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
        IEnumerable<PageMetadata> GetDraftPages();

        PageMetadata GetPage(string path);

        /// <summary>
        /// Get pages grouped by tag
        /// </summary>
        IDictionary<string, IEnumerable<PageMetadata>> GetPagesByTag();

        IEnumerable<string> GetTags();
    }
}