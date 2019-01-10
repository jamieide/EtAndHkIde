using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    // This was originally implemented as a value type but that caused a lot of duplicate data on serialization.

    public static class TagValues
    {
        // System
        public const string Featured = "Featured";
        public static readonly ISet<string> SystemTags = new HashSet<string>() { Featured };

        // People
        public const string TimothyIde = "Timothy Ide";
        public const string JacobIde = "Jacob Ide";
        public const string ElmoreIde = "Elmore Ide";
        public const string HoraceIde = "Horace Ide";
        public const string WilliamIde = "William Ide";
        public const string RichardIde = "Richard Ide";
        public const string TimIde = "Tim Ide";
        public const string GeorgeGray = "George Gray";
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

        // Places
        public const string Passumpsic = "Passumpsic";
        public const string StJohnsbury = "St. Johnsbury";
        public static readonly ISet<string> PlaceTags = new HashSet<string>() { Passumpsic, StJohnsbury };
    }
}