using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SearchyRequest
    {
        public SearchyRequest()
        {
            Conditions = new List<SearchyCondition>();
            Sorts = new List<SearchySort>();
            //PageSize = 1000;
        }

        public SearchyRequest(string[] filters, string[] sorts = null, int pageSize = 0, int pageIndex = 0, bool countRows = false) :
            this()
        {

            if (filters != null)
            {
                var cond = new SearchyCondition();

                foreach (var str in filters)
                    cond.Filters.Add(new SearchyFilter(str));

                Conditions.Add(cond);
            }

            if (sorts != null)
            { 
            
            }


            PageSize = pageSize;
            PageIndex = pageIndex;
            CountRows = countRows;

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
        public ICollection<SearchySort> Sorts { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public bool CountRows { get; set; }

        public override string ToString()
        {
            string filtersStr = string.Empty;
            string sortsStr = string.Empty;

            if (Conditions.Count >= 1)
            {
                var filters = Conditions.First().Filters.Select(f => f.ToString());
                filtersStr = String.Join("&", filters);
            }

            var sorts = Sorts.Select(s => s.ToString());
            sortsStr = String.Join("&", sorts);

            var result = string.Empty;
            if (!string.IsNullOrEmpty(filtersStr)) result = $"{filtersStr}&";
            if (!string.IsNullOrEmpty(sortsStr)) result = $"{result}{sortsStr}&";
            if (PageSize > 0) result = $"{result}size={PageSize}&";
            if (PageIndex > 0) result = $"{result}page={PageIndex}&";
            if (CountRows) result = $"{result}count={CountRows}&";

            if (!string.IsNullOrEmpty(result)) result = result.Remove(result.Length - 1);

            return result;

        }
    }
}
