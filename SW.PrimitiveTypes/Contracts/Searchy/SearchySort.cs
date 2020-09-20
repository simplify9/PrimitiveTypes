using System;
using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public class SearchySort : ICloneable, IEquatable<SearchySort>
    {
        public string Field { get; set; }
        public SearchySortOrder  Sort { get; set; }

        public SearchySort() {}

        public SearchySort(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                var arr = queryString.Split(':');
                if (arr.Length == 2)
                {
                    Field = arr[0];
                    Sort = (SearchySortOrder)int.Parse(arr[1]);
                    
                }
            }
        }

        public SearchySort(string field, SearchySortOrder sortOrder)
        {
            Field = field;
            Sort = sortOrder;
        }

        public override string ToString()
        {
            return $"sort={Field}:{(int)Sort}";
        }

        public object Clone()
        {
            return new SearchySort
            {
                Field = Field,
                Sort = Sort
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchySort);
        }

        public bool Equals(SearchySort other)
        {
            return other != null &&
                   Field == other.Field &&
                   Sort == other.Sort;
        }

        public override int GetHashCode()
        {
            int hashCode = -76431088;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Field);
            hashCode = hashCode * -1521134295 + Sort.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SearchySort left, SearchySort right)
        {
            return EqualityComparer<SearchySort>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchySort left, SearchySort right)
        {
            return !(left == right);
        }
    }
}
