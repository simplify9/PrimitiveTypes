using System;

namespace SW.PrimitiveTypes
{

    public class SearchySort
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


    }
}
