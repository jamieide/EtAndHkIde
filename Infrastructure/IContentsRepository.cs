using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        ContentPageCollection GetContentPages();
        IEnumerable<ContentPage> GetPublishedContentPages(int? count, ContentPageType type);

        IEnumerable<ContentItem> GetImages(string path);
        ContentItem GetImage(string path, string imageFileName);
    }
}