using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SearchyRequest
    {
        public SearchyRequest()
        {
            Conditions = new List<SearchyCondition>();
            Orders = new List<SearchyOrder>();
            PageSize = 1000;
        }

        public SearchyRequest(SearchyCondition condition) : 
            this()
        {
            Conditions.Add(condition);
        }

        public SearchyRequest(string field, SearchyRule rule, object value) :
            this(new SearchyCondition(new SearchyFilter(field, rule, value)))
        { }

        public ICollection<SearchyCondition> Conditions { get; set; }
        public ICollection<SearchyOrder> Orders { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public bool CountRows { get; set; }
    }
}
