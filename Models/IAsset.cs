using System;
using System.IO;

namespace EtAndHkIde.Models
{
    public interface IAsset
    {
        string Path { get; set; }
        string Title { get; set; }
        DateTime PublishDate { get; set; }
        string[] Tags { get; set; }
    }
}