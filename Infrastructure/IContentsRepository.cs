using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        IEnumerable<ContentItem> GetPages(int? count);
        IEnumerable<ContentItem> GetHighlightPages(int? count);
        int ImageCount();
    }
}