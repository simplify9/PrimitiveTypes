using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public static class StringExtensions
    {

        public static string NullIfEmpty(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;
            return input;
        }

        public static string EmptyIfNull(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            return input;
        }

    }
}
