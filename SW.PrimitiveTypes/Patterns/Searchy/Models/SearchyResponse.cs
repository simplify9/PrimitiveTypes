using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SearchyResponse<TModel> : SearchyResponse
    {
        public SearchyResponse()
        {
            Result = new List<TModel>();

        }

        IEnumerable<TModel> result;
        public new IEnumerable<TModel> Result
        {
            get
            {
                return result;
            }
            set
            {
                base.Result = value;
                result = value;
            }
        }
    }

    public class SearchyResponse
    {
        public SearchyResponse()
        {
            Result = new List<object>();
        }

        public IEnumerable Result { get; set; }
        public int TotalCount { get; set; }
    }
}
