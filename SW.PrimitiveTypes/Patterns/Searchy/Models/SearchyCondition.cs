using System.Collections.Generic;
using System;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyCondition
    {
        public ICollection<SearchyFilter> Filters { get; set; }

        public SearchyCondition() => Filters = new List<SearchyFilter>();

        public SearchyCondition(SearchyFilter filter)
        {
            Filters = new List<SearchyFilter> { filter };
        }

        public SearchyCondition(ICollection<SearchyFilter> filters)
        {
            Filters = filters;
        }

        public SearchyCondition(ICollection<ISearchyFilterTyped> filters)
        {
            Filters = filters.Select(f => new SearchyFilter(f)).ToList();
        }

        public SearchyCondition(ICollection<ISearchyFilter> filters)
        {
            Filters = filters.Select(f => new SearchyFilter(f)).ToList();
        }









    }
}
