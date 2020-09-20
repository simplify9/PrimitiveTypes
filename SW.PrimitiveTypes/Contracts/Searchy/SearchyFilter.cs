using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyFilter : ISearchyFilterTyped, ICloneable, IEquatable<SearchyFilter>
    {
        //object value;

        public string Field { get; set; }

        public object Value
        {
            get
            {

                if (!(ValueString is null)) return ValueString;
                if (!(ValueStringArray is null)) return ValueStringArray;
                if (!(ValueDateTime is null)) return ValueDateTime;
                if (!(ValueDateTimeArray is null)) return ValueDateTimeArray;
                if (!(ValueDecimal is null)) return ValueDecimal;
                if (!(ValueDecimalArray is null)) return ValueDecimalArray;

                return null;
            }
            set
            {
                if (value == null)
                {
                    ValueString = null;
                    ValueStringArray = null;
                    ValueDecimal = null;
                    ValueDecimalArray = null;
                    ValueDateTime = null;
                    ValueDateTimeArray = null;
                }
                else if (value.GetType() == typeof(DateTime))
                    ValueDateTime = (DateTime?)value;
                    
                else if (value.GetType() == typeof(DateTime[]))
                    ValueDateTimeArray = (DateTime[])value;

                else if (value.GetType() == typeof(decimal)) 
                    ValueDecimal = (decimal?)value;

                else if (value.GetType() == typeof(double)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if (value.GetType() == typeof(long)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if (value.GetType() == typeof(int)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if (value.GetType() == typeof(short)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if (value.GetType() == typeof(byte)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if (value.GetType() == typeof(bool)) 
                    ValueDecimal = (decimal?)value.ConvertValueToType(typeof(decimal?));

                else if(value.GetType() == typeof(decimal[])) 
                    ValueDecimalArray = (decimal[])value;

                else if(value.GetType() == typeof(string)) 
                    ValueString = (string)value;

                else if(value.GetType() == typeof(string[])) 
                    ValueStringArray = (string[])value;
            }
        }
        public SearchyRule Rule { get; set; }

        public string ValueString { get; set; }
        public string[] ValueStringArray { get; set; }

        public decimal? ValueDecimal { get; set; }
        public decimal[] ValueDecimalArray { get; set; }

        public DateTime? ValueDateTime { get; set; }
        public DateTime[] ValueDateTimeArray { get; set; }

        public SearchyFilter() { }

        public SearchyFilter(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                var arr = queryString.Split(new char[] { ':' }, 3);
                if (arr.Length == 3)
                {
                    Field = arr[0];
                    Rule = (SearchyRule)int.Parse(arr[1]);

                    //handle arrays

                    if (arr[2].StartsWith(SearchyDataType.Text + "|"))
                    {
                        Value = arr[2].Split(new char[] { '|' }).Skip(1).Select(value => decimal.Parse(value)).ToArray();
                    }

                    else if (arr[2].StartsWith(SearchyDataType.Number + "|"))
                    {
                        Value = arr[2].Split(new char[] { '|' }).Skip(1).Select(value => decimal.Parse(value)).ToArray();
                    }

                    else if (arr[2].StartsWith(SearchyDataType.Date + "|"))
                    {
                        Value = arr[2].Split(new char[] { '|' }).Skip(1).Select(value => DateTime.Parse(value)).ToArray();
                    }

                    else

                        Value = arr[2];
                }
            }

        }

        public SearchyFilter(string field, SearchyRule rule, object value)
        {
            Field = field;
            Value = value;
            Rule = rule;
        }

        public SearchyFilter(ISearchyFilter filter) : this(filter.Field, filter.Rule, filter.Value) { }

        public SearchyFilter(ISearchyFilterTyped filter) : this((ISearchyFilter)filter)
        {

            ValueDateTime = filter.ValueDateTime;
            ValueDecimal = filter.ValueDecimal;
            ValueString = filter.ValueString;

            ValueDateTimeArray = filter.ValueDateTimeArray;
            ValueDecimalArray = filter.ValueDecimalArray;
            ValueStringArray = filter.ValueStringArray;
        }

        public override string ToString()
        {
            string valueString = null;

            if (ValueString != null) valueString = ValueString;
            else if (ValueStringArray != null) valueString = SearchyDataType.Text + "|" + string.Join("|", ValueStringArray.Select(value => value.ToString()));
            else if (ValueDecimal != null) valueString = ValueDecimal.ToString();
            else if (ValueDecimalArray != null) valueString = SearchyDataType.Number + "|" + string.Join("|", ValueDecimalArray.Select(value => value.ToString()));
            else if (ValueDateTime != null) valueString = ValueDateTime.Value.ToString("O");
            else if (ValueDateTimeArray != null) valueString = SearchyDataType.Date + "|" + string.Join("|", ValueDateTimeArray.Select(value => value.ToString("O")));
            else if (Value != null) valueString = Value.ToString();

            return $"filter={Field}:{(int)Rule}:{((valueString == null) ? null : Uri.EscapeDataString(valueString))}";
        }

        public object Clone()
        {
            return new SearchyFilter
            {
                Field = Field,
                Rule = Rule,
                Value = Value,
                //ValueString = ValueString,
                //ValueStringArray = ValueStringArray,
                //ValueDecimal = ValueDecimal,
                //ValueDecimalArray = ValueDecimalArray,
                //ValueDateTime = ValueDateTime,
                //ValueDateTimeArray = ValueDateTimeArray
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchyFilter);
        }

        public bool Equals(SearchyFilter other)
        {
            //if (value == null)
            return other != null &&
                   StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                   Rule == other.Rule &&
                   ValueString == other.ValueString &&
                   ValueDecimal == other.ValueDecimal &&
                   ValueDateTime == other.ValueDateTime &&
                   CollectionComparer<string>.Compare(ValueStringArray, other.ValueStringArray) &&
                   CollectionComparer<decimal>.Compare(ValueDecimalArray, other.ValueDecimalArray) &&
                   CollectionComparer<DateTime>.Compare(ValueDateTimeArray, other.ValueDateTimeArray);

            //else
            //    return other != null &&
            //           StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
            //           Rule == other.Rule &&
            //           value == other.value;
        }

        public override int GetHashCode()
        {
            int hashCode = -141615765;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Field);
            hashCode = hashCode * -1521134295 + Rule.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ValueString);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(ValueStringArray);
            hashCode = hashCode * -1521134295 + ValueDecimal.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal[]>.Default.GetHashCode(ValueDecimalArray);
            hashCode = hashCode * -1521134295 + ValueDateTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime[]>.Default.GetHashCode(ValueDateTimeArray);
            return hashCode;
        }

        public static bool operator ==(SearchyFilter left, SearchyFilter right)
        {
            return EqualityComparer<SearchyFilter>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchyFilter left, SearchyFilter right)
        {
            return !(left == right);
        }
    }
}
