using System;

namespace SW.PrimitiveTypes
{

    public class SearchySort
    {


        public string Field { get; set; }

        public SearchySortOrder  Sort { get; set; }

        public SearchySort()
        {
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


    }
}
