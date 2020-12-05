using System;

namespace EtAndHkIde.Infrastructure
{
    public static class Utilities
    {
        public static bool HasValue(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static string ToShortDateString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToShortDateString() : string.Empty;
        }
    }
}