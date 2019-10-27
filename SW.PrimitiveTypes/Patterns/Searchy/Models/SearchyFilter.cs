


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
                else if (!(ValueStringArray is null)) return ValueStringArray;
                
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
            //ValueBool = filter.ValueBool;
            //ValueByte = filter.ValueByte;
            //ValueInt = filter.ValueInt;
            //ValueLong = filter.ValueLong;
            ValueString = filter.ValueString;
            //ValueDate = filter.ValueDate;
            //ValueByteArray  = filter.ValueByteArray;
            //ValueIntArray = filter.ValueIntArray;
            //ValueLongArray  = filter.ValueLongArray;
            ValueStringArray = filter.ValueStringArray;
        }
    }
}
