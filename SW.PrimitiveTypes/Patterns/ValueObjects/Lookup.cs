using System;
using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public class Lookup
    {
        public Lookup()
        {
        }

        public string DictionaryUrl { get; set; }
        public string ValueUrl { get; set; }
        public IDictionary<string, string> Dictionary { get; set; }

        public LookupType Type
        {
            get
            {
                if (Dictionary != null)
                    return LookupType.Dictionary;
                if (DictionaryUrl != null)
                    return LookupType.Api;
                return LookupType.Unknown; 
            }
        }
        public bool HasValueUrl => ValueUrl != null;

        public static Lookup FromSearchy(string searchyUrl, bool noValue = false)
        {
            if (string.IsNullOrWhiteSpace(searchyUrl))
            {
                throw new ArgumentException($"'{nameof(searchyUrl)}' cannot be null or whitespace", nameof(searchyUrl));
            }

            return new Lookup
            {
                //Type = LookupType.Api,
                DictionaryUrl = $"{searchyUrl}?lookup=true&search={{search}}&format=1",
                ValueUrl = noValue ? null : $"{searchyUrl}/{{value}}?lookup=true&format=1"
            };
        }

        public static Lookup From(string listUrl, string valueUrl = null)
        {
            if (string.IsNullOrWhiteSpace(listUrl))
            {
                throw new ArgumentException($"'{nameof(listUrl)}' cannot be null or whitespace", nameof(listUrl));
            }

            return new Lookup
            {
                //Type = LookupType.Api,
                DictionaryUrl = listUrl,
                ValueUrl = valueUrl
            };
        }

        public static Lookup From(IDictionary<string, string> dictionary)
        {
            return new Lookup
            {
                //Type = LookupType.Dictionary,
                Dictionary = dictionary
            };
        }

        public string ApplyValue(object value)
        {
            if (value == null) return null;
            if (ValueUrl == null) return null;
            return ValueUrl.Replace("{value}", value.ToString());
        }

        public string ApplySearch(string searchPhrase = null)
        {
            if (searchPhrase == null) searchPhrase = string.Empty;
            return DictionaryUrl.Replace("{search}", searchPhrase);
        }
    }

    public enum LookupType
    {
        Unknown = 0,
        Api = 1,
        Dictionary = 2
    }
}
