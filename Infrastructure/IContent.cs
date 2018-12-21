using System;

namespace EtAndHkIde.Infrastructure
{
    public interface IContent
    {
        string Title { get; }
        string Description { get; }
        DateTime? PublishDate { get; }
    }
}