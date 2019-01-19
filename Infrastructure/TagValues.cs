using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EtAndHkIde.Infrastructure
{
    // This was originally implemented as a value type but that caused a lot of duplicate data on serialization.

    public static class TagValues
    {
        private static IEnumerable<string> GetConstantStringValues(Type t)
        {
            return t.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(string))
                .Select(x => (string)x.GetRawConstantValue());
        }

        public static class System
        {
            static System()
            {
                var values = GetConstantStringValues(typeof(System));
                All = new HashSet<string>(values);
            }

            public static ISet<string> All { get; }

            public const string Featured = "Featured";
        }

        public static class People
        {
            static People()
            {
                var values = GetConstantStringValues(typeof(People));
                All = new HashSet<string>(values);
            }

            public static ISet<string> All { get; }

            public const string TimothyIde = "Timothy Ide";
            public const string JacobIde = "Jacob Ide";
            public const string ElmoreIde = "Elmore Ide";
            public const string CynthiaIde = "Cynthia Ide";
            public const string HoraceIde = "Horace Ide";
            public const string WilliamIde = "William Ide";
            public const string RichardIde = "Richard Ide";
            public const string TimIde = "Tim Ide";
            public const string RobertIde = "Rob Ide";
            public const string MaitlandBean = "Maitland Bean";
            public const string GeorgeGray = "George Gray";
       }

        public static class Places
        {
            static Places()
            {
                var values = GetConstantStringValues(typeof(Places));
                All = new HashSet<string>(values);
            }

            public static ISet<string> All { get; }

            public const string Passumpsic = "Passumpsic";
            public const string StJohnsbury = "St. Johnsbury";
        }
    }
}