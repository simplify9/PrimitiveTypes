using System.Collections.Generic;
using System;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyCondition
    {
        public ICollection<SearchyFilter> Filters { get; set; }

        public SearchyCondition() => Filters = new List<SearchyFilter>();

        public SearchyCondition(string field, SearchyRule rule, object value) : this()
        {
            Filters.Add(new SearchyFilter(field, rule, value)); 
        }

        //public SearchyCondition(ISearchyFilter filter)
        //{
        //    Filters = new List<SearchyFilter> { new SearchyFilter(filter) };
        //}

        public SearchyCondition(ISearchyFilterTyped filter)
        {
            Filters = new List<SearchyFilter> { new SearchyFilter(filter) };
        }

        public SearchyCondition(IEnumerable<SearchyFilter> filters)
        {
            Filters = filters.ToList();
        }

        public SearchyCondition(IEnumerable<ISearchyFilterTyped> filters)
        {
            Filters = filters.Select(f => new SearchyFilter(f)).ToList();
        }

        //public SearchyCondition(IEnumerable<ISearchyFilter> filters)
        //{
        //    Filters = filters.Select(f => new SearchyFilter(f)).ToList();
        //}
    }
}
