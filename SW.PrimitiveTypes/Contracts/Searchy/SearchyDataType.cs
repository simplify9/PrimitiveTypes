

using System;
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
                            SearchyRule.Range,
                    };

                case Boolean:

                    return new SearchyRule[]
                    {
                            SearchyRule.EqualsTo
                    };

            }

            return null;

        }

        public static string TypeStringFor(Type type)
        {
            var nakedType = Nullable.GetUnderlyingType(type) ?? type;

            switch (Type.GetTypeCode(nakedType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:

                    return Number;

                case TypeCode.DateTime:

                    return Date;

                case TypeCode.Boolean:

                    return Boolean;

                default:

                    return Text;
            }
        }
    };
}


