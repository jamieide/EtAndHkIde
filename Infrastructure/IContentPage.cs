using System;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentPage
    {
        string Title { get; }
        string Description { get; }
        DateTime? PublishDate { get; }
    }
}