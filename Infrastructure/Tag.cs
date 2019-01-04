using System.Runtime.CompilerServices;

namespace EtAndHkIde.Infrastructure
{
    public class Tag
    {
        private Tag(string name, TagType tagType, [CallerMemberName] string caller = null)
        {
            Name = name;
            NormalizedName = caller?.ToLowerInvariant();
            TagType = tagType;
        }

        public string Name { get; }
        public string NormalizedName { get; }
        public TagType TagType { get; }

        public override string ToString() => Name;

        // System
        public static Tag Featured = new Tag("Featured", TagType.Featured);

        // People
        public static Tag TimothyIde = new Tag("Timothy Ide", TagType.Person);
        public static Tag JacobIde = new Tag("Jacob Ide", TagType.Person);
        public static Tag ElmoreIde = new Tag("Elmore Ide", TagType.Person);
        public static Tag HoraceIde = new Tag("Horace Ide", TagType.Person);
        public static Tag WilliamIde = new Tag("William Ide", TagType.Person);
        public static Tag RichardIde = new Tag("Richard Ide", TagType.Person);
        public static Tag TimIde = new Tag("Tim Ide", TagType.Person);
        public static Tag GeorgeGray = new Tag("George Gray", TagType.Person);

        // Places
        public static Tag StJohnsbury = new Tag("St. Johnsbury", TagType.Place);
        public static Tag Passumpsic = new Tag("Passumpsic", TagType.Place);
    }
}