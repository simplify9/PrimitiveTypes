using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface  ISearchyFilterSetup
    {
        string Type { get; set; }
        string Text { get; set; }
        string Field { get; set; }
        bool Required { get; set; }
        bool Default { get; set; }
        ICollection<SearchyRule> Rules { get; set; }
    }
}
