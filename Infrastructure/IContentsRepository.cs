using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        IEnumerable<ContentItem> GetPages(int? count);
        IEnumerable<ContentItem> GetHighlightPages(int? count);
        ContentItem GetImage(string path);
        int ImageCount();

        IEnumerable<ContentPage> ContentPages { get; }
        IEnumerable<ContentPage> GetPublishedContentPages(int? count, ContentPageType type);
    }
}