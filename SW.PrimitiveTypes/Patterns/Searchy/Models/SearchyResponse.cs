using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SearchyResponse<TModel> 
    {
        public SearchyResponse()
        {
            Result = new List<TModel>();
        }

        public  IEnumerable<TModel> Result { get; set; }

        public int TotalCount { get; set; }

        public SearchyResponse ToSearchyResponse()
        {
            return new SearchyResponse
            {
                TotalCount = this.TotalCount,
                Result = this.Result
            };
        }

    }

    public class SearchyResponse
    {
        public SearchyResponse()
        {
        }

        public IEnumerable Result { get; set; }
        public int TotalCount { get; set; }
    }
}
