using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface ISearchyFilter
    {
        string Field { get; set; }
        object Value { get; set; }
        SearchyRule Rule { get; set; }
    }
}
