using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        IEnumerable<ContentItem> GetPages();
        IEnumerable<ContentItem> GetRecentPages(int count);
    }
}