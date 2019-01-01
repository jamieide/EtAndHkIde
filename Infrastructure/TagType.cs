using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EtAndHkIde.Infrastructure
{
    public class TagType
    {
        private TagType(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get;  }
        public string Icon { get;  }

        public static TagType Person = new TagType("Person", "fas fa-user-friends");
        public static TagType Place = new TagType("Place", "fas fa-map-pin");

        public static IEnumerable<TagType> AllTagTypes { get; } = new[] {Person, Place};
    }
}