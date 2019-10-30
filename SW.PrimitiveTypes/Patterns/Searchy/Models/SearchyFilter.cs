using System;

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
                if (!(ValueDateTime  is null)) return ValueDateTime;
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

        public SearchyFilter() {}

        public SearchyFilter(string field, SearchyRule rule, object value)
        {
            Field = field;
            Value = value;
            Rule = rule;
        }

        public SearchyFilter(ISearchyFilter filter) : this(filter.Field, filter.Rule, filter.Value ) {}

        public SearchyFilter(ISearchyFilterTyped filter) : this((ISearchyFilter) filter)
        {

            ValueDateTime = filter.ValueDateTime;
            ValueDecimal = filter.ValueDecimal;
            ValueString = filter.ValueString;

            ValueDateTimeArray = filter.ValueDateTimeArray;
            ValueDecimalArray = filter.ValueDecimalArray;
            ValueStringArray = filter.ValueStringArray;
        }
    }
}
