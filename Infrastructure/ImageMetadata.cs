using System;

namespace EtAndHkIde.Infrastructure
{
    public class ImageMetadata
    {
        public string Path { get; set; }
        public string ThumbnailPath { get; set; }
        // todo should I bother with title?
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Copyright { get; set; } = "";
        public string[] Tags { get; set; } = new string[0];

        public override string ToString() => Path;
    }
}