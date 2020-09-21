using System;
using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    internal static class QueryStringParser
    {
        public static IDictionary<string, IEnumerable<string>> Parse(string queryString)
        {
            var rc = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

            if (string.IsNullOrWhiteSpace(queryString))
                return rc;

            var ar1 = queryString.Split(new char[] { '&', '?' });

            foreach (string row in ar1)
            {
                if (string.IsNullOrEmpty(row)) continue;
                int index = row.IndexOf('=');
                if (index < 0) continue;

                var key = Uri.UnescapeDataString(row.Substring(0, index));
                if (string.IsNullOrWhiteSpace(key)) continue;

                var value = Uri.UnescapeDataString(row.Substring(index + 1));
                if (string.IsNullOrWhiteSpace(value)) continue;

                if (rc.TryGetValue(key, out var values))
                    ((ISet<string>)values).Add(value);

                else
                    rc.Add(key, new HashSet<string>
                    {
                        value
                    });
            }
            return rc;
        }
    }
}
