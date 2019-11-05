

using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public static class SearchyDataType
    {
        public const string Text = "text";
        public const string Date = "date";
        public const string Number = "numeric";
        public const string Boolean = "boolean";


        public static ICollection<SearchyRule> RulesFor(string dataType)
        {
            switch (dataType)
            {
                case Text:

                        return new SearchyRule[]
                        {
                            SearchyRule.EqualsTo,
                            SearchyRule.NotEqualsTo,
                            SearchyRule.Contains,
                            SearchyRule.StartsWith,
                        };

                case Number:

                        return new SearchyRule[]
                        {
                            SearchyRule.EqualsTo,
                            SearchyRule.NotEqualsTo,
                            SearchyRule.LessThan,
                            SearchyRule.LessThanOrEquals,
                            SearchyRule.GreaterThan,
                            SearchyRule.GreaterThanOrEquals,

                        };

                case Date:

                        return new SearchyRule[]
                        {
                            SearchyRule.LessThan,
                            SearchyRule.LessThanOrEquals,
                            SearchyRule.GreaterThan,
                            SearchyRule.GreaterThanOrEquals,
                        };

                case Boolean:

                        return new SearchyRule[]
                        {
                            SearchyRule.EqualsTo
                        };

            }

            return null;

        }
    };


}


