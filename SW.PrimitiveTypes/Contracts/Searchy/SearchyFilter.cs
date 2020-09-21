using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyFilter : ISearchyFilterTyped, ICloneable, IEquatable<SearchyFilter>
    {
        public string Field { get; set; }
        public SearchyRule Rule { get; set; }

        private object value;
        public object Value
        {
            get => value;
            set => this.value = value;
        }

        public string ValueString
        {
            get => (string)value;
            set => this.value = value;
        }

        public string[] ValueStringArray
        {
            get => (string[])value;
            set => this.value = value;
        }

        public decimal? ValueDecimal
        {
            get => (decimal?)value.ConvertValueToType(typeof(decimal?));
            set => this.value = value;
        }

        public decimal[] ValueDecimalArray
        {
            get => (decimal[])value;
            set => this.value = value;
        }

        public DateTime? ValueDateTime
        {
            get => (DateTime?)value;
            set => this.value = value;
        }

        public DateTime[] ValueDateTimeArray
        {
            get => (DateTime[])value;
            set => this.value = value;
        }

        public SearchyFilter() 
        { 
        }

        public SearchyFilter(string queryString)
        {
            if (string.IsNullOrEmpty(queryString)) return;

            var parsedProperties = queryString.Split(new char[] { ':' }, 3);
            if (parsedProperties.Length != 3) return;

            Field = parsedProperties[0];
            Rule = (SearchyRule)int.Parse(parsedProperties[1]);

            //handle arrays
            if (parsedProperties[2].StartsWith(SearchyDataType.Text + "|"))
                value = parsedProperties[2].Split(new char[] { '|' }).Skip(1).ToArray();
            else if (parsedProperties[2].StartsWith(SearchyDataType.Number + "|"))
                value = parsedProperties[2].Split(new char[] { '|' }).Skip(1).Select(i => decimal.Parse(i)).ToArray();
            else if (parsedProperties[2].StartsWith(SearchyDataType.Date + "|"))
                value = parsedProperties[2].Split(new char[] { '|' }).Skip(1).Select(i => DateTime.Parse(i)).ToArray();
            else
                value = parsedProperties[2].Length == 0 ? null : parsedProperties[2];
        }

        public SearchyFilter(string field, SearchyRule rule, object value)
        {
            Field = field;
            Rule = rule;
            this.value = value;
        }
        public SearchyFilter(ISearchyFilter filter) :
            this(filter.Field, filter.Rule, filter.Value)
        { 
        }
        public override string ToString()
        {
            string valueSerialized;

            if (value == null) 
                valueSerialized = null;

            else if (value is string) 
                valueSerialized = ValueString;

            else if (value is string[]) 
                valueSerialized = SearchyDataType.Text + "|" + string.Join("|", ValueStringArray.Select(value => value.ToString()));
            
            else if (value is decimal?) 
                valueSerialized = ValueDecimal.ToString();
            
            else if (value is decimal[]) 
                valueSerialized = SearchyDataType.Number + "|" + string.Join("|", ValueDecimalArray.Select(value => value.ToString()));
            
            else if (value is DateTime?) 
                valueSerialized = ValueDateTime.Value.ToString("O");
            
            else if (value is DateTime[]) 
                valueSerialized = SearchyDataType.Date + "|" + string.Join("|", ValueDateTimeArray.Select(value => value.ToString("O")));
            
            else 
                valueSerialized = value.ToString();

            return $"filter={Field}:{(int)Rule}:{((valueSerialized == null) ? null : Uri.EscapeDataString(valueSerialized))}";
        }

        public object Clone()
        {
            return new SearchyFilter
            {
                Field = Field,
                Rule = Rule,
                value = value,
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchyFilter);
        }

        public bool Equals(SearchyFilter other)
        {
            if (other == null)
                return false;

            else if (value is string[] && other.value is string[])
                return StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                       Rule == other.Rule &&
                       CollectionComparer<string>.Compare(ValueStringArray, other.ValueStringArray);

            else if (value is DateTime[] && other.value is DateTime[])
                return StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                       Rule == other.Rule &&
                       CollectionComparer<DateTime>.Compare(ValueDateTimeArray, other.ValueDateTimeArray);

            else if (value is decimal[] && other.value is decimal[])
                return StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                       Rule == other.Rule &&
                       CollectionComparer<decimal>.Compare(ValueDecimalArray, other.ValueDecimalArray);

            else if (value != null)
                return StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                       Rule == other.Rule &&
                       value.Equals(other.value);

            else if (other.value != null)
                return false;

            else
                return StringComparer.OrdinalIgnoreCase.Equals(Field, other.Field) &&
                       Rule == other.Rule;
        }

        public override int GetHashCode()
        {
            int hashCode = -141615765;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Field);
            hashCode = hashCode * -1521134295 + Rule.GetHashCode();
            hashCode = hashCode * -1521134295 + value.GetHashCode();
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
