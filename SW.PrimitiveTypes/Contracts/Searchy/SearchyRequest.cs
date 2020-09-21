using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyRequest : ICloneable, IEquatable<SearchyRequest>
    {
        public SearchyRequest()
        {
            Conditions = new List<SearchyCondition>();
            Sorts = new List<SearchySort>();
        }

        public SearchyRequest(string queryString) : this()
        {
            var queryDictionary = QueryStringParser.Parse(queryString);

            if (queryDictionary.TryGetValue("filter", out var filters))
            {
                var cond = new SearchyCondition();
                Conditions.Add(cond);
                foreach (var str in filters)
                    cond.Filters.Add(new SearchyFilter(str));
            }

            if (queryDictionary.TryGetValue("sort", out var sorts))
                foreach (var str in sorts)
                    Sorts.Add(new SearchySort(str));

            if (queryDictionary.TryGetValue("size", out var sizes) && 
                sizes.Any() && 
                int.TryParse(sizes.First(), out var pageSize))
                PageSize = pageSize;

            if (queryDictionary.TryGetValue("page", out var pages) && 
                pages.Any() && 
                int.TryParse(pages.First(), out var pageIndex))
                PageIndex = pageIndex;

            if (queryDictionary.TryGetValue("count", out var counts) &&
                counts.Any() && 
                bool.TryParse(counts.First(), out var countRows))
                CountRows = countRows;
        }

        public SearchyRequest(string[] filters, string[] sorts = null, int pageSize = 0, int pageIndex = 0, bool countRows = false) : this()
        {
            if (filters != null)
            {
                var cond = new SearchyCondition();
                Conditions.Add(cond);
                foreach (var str in filters)
                    cond.Filters.Add(new SearchyFilter(str));
            }

            if (sorts != null)
                foreach (var str in sorts)
                    Sorts.Add(new SearchySort(str));

            PageSize = pageSize;
            PageIndex = pageIndex;
            CountRows = countRows;
        }

        public SearchyRequest(SearchyCondition condition) : this()
        {
            Conditions.Add(condition);
        }

        public SearchyRequest(string field, SearchyRule rule, object value) :
            this(new SearchyCondition(field, rule, value))
        {
        }

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
                filtersStr = string.Join("&", filters);
            }

            var sorts = Sorts.Select(s => s.ToString());
            sortsStr = string.Join("&", sorts);

            var result = string.Empty;
            if (!string.IsNullOrEmpty(filtersStr)) result = $"{filtersStr}&";
            if (!string.IsNullOrEmpty(sortsStr)) result = $"{result}{sortsStr}&";
            if (PageSize > 0) result = $"{result}size={PageSize}&";
            if (PageIndex > 0) result = $"{result}page={PageIndex}&";
            if (CountRows) result = $"{result}count={CountRows}&";

            if (!string.IsNullOrEmpty(result)) result = result.Remove(result.Length - 1);

            return result;
        }

        public object Clone()
        {
            return new SearchyRequest
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                CountRows = CountRows,
                Conditions = Conditions.Select(i => (SearchyCondition)i.Clone()).ToList(),
                Sorts = Sorts.Select(i => (SearchySort)i.Clone()).ToList()
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchyRequest);
        }

        public bool Equals(SearchyRequest other)
        {
            return other != null &&
                   CollectionComparer<SearchyCondition>.Compare(Conditions, other.Conditions) &&
                   CollectionComparer<SearchySort>.Compare(Sorts, other.Sorts) &&
                   PageSize == other.PageSize &&
                   PageIndex == other.PageIndex &&
                   CountRows == other.CountRows;
        }

        public override int GetHashCode()
        {
            int hashCode = -1859068553;
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<SearchyCondition>>.Default.GetHashCode(Conditions);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<SearchySort>>.Default.GetHashCode(Sorts);
            hashCode = hashCode * -1521134295 + PageSize.GetHashCode();
            hashCode = hashCode * -1521134295 + PageIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + CountRows.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SearchyRequest left, SearchyRequest right)
        {
            return EqualityComparer<SearchyRequest>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchyRequest left, SearchyRequest right)
        {
            return !(left == right);
        }
    }
}
