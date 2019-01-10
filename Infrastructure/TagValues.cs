using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    // This was originally implemented as a value type but that caused a lot of duplicate data on serialization.

    public static class TagValues
    {
        // System
        public static readonly ISet<string> SystemTags = new HashSet<string>() { Featured };
        public const string Featured = "Featured";

        // People
        public static readonly ISet<string> PersonTags = new HashSet<string>()
        {
            TimothyIde,
            JacobIde,
            ElmoreIde,
            HoraceIde,
            WilliamIde,
            RichardIde,
            TimIde,
            GeorgeGray
        };
        public const string TimothyIde = "Timothy Ide";
        public const string JacobIde = "Jacob Ide";
        public const string ElmoreIde = "Elmore Ide";
        public const string HoraceIde = "Horace Ide";
        public const string WilliamIde = "William Ide";
        public const string RichardIde = "Richard Ide";
        public const string TimIde = "Tim Ide";
        public const string GeorgeGray = "George Gray";

        // Places
        public static readonly ISet<string> PlaceTags = new HashSet<string>() { Passumpsic, StJohnsbury };
        public const string Passumpsic = "Passumpsic";
        public const string StJohnsbury = "St. Johnsbury";

        public static string TagIcon(string tagValue)
        {
            if (tagValue == TagValues.Featured)
            {
                return "tag fas fa-award";
            }
            if (TagValues.PersonTags.Contains(tagValue))
            {
                return "tag fas fa-user";
            }
            if (TagValues.PlaceTags.Contains(tagValue))
            {
                return "tag fas fa-map-pin";
            }
            return "tag fas fa-tag";
        }
    }
}