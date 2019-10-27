using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface ISearchyFilterTyped : ISearchyFilter
    {
        string ValueString { get; set; }
        string[] ValueStringArray { get; set; }
    }
}
