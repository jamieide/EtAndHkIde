﻿using System;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsHighlight { get; set; }
    }
}