using System.Runtime.CompilerServices;

namespace EtAndHkIde.Infrastructure
{
    public class Tag
    {
        private Tag(string name, string description, TagType tagType, [CallerMemberName] string caller = null)
        {
            Name = name;
            NormalizedName = caller;
            Description = description;
            TagType = tagType;
        }

        public string Name { get; }
        public string NormalizedName { get; }
        public string Description { get; }
        public TagType TagType { get; }

        public override string ToString() => Name;

        // People
        public static Tag TimothyIde = new Tag("Timothy Ide", "Timothy Ide", TagType.Person);
        public static Tag JacobIde = new Tag("Jacob Ide", "Jacob Ide", TagType.Person);
        public static Tag ElmoreIde = new Tag("Elmore Ide", "Elmore Ide", TagType.Person);
        public static Tag HoraceIde = new Tag("Horace Ide", "Horace Ide", TagType.Person);
        public static Tag WilliamIde = new Tag("William Ide", "William Ide", TagType.Person);
        public static Tag RichardIde = new Tag("Richard Ide", "Richard Ide", TagType.Person);
        public static Tag TimIde = new Tag("Tim Ide", "Tim Ide", TagType.Person);
        public static Tag GeorgeGray = new Tag("George Gray", "George Gray", TagType.Person);

        // Places
        public static Tag StJohnsbury = new Tag("St. Johnsbury", "St. Johnsbury, Vermont", TagType.Place);
        public static Tag Passumpsic = new Tag("Passumpsic", "Passumpsic Vermont is a village of Barnet.", TagType.Place);
    }
}