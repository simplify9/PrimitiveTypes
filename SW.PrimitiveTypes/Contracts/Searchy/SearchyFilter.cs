using System;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyFilter : ISearchyFilterTyped
    {
        object value;

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

                return value;
            }
            set
            {
                this.value = value;
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
    }
}
