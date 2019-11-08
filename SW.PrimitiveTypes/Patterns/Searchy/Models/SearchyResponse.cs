using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface ISearchyResponse<out TModel>
    {
        IEnumerable<TModel> Result { get; }
        int TotalCount { get; }
    }

    public class SearchyResponse<TModel> : ISearchyResponse<TModel>
    {
        public SearchyResponse()
        {
            Result = new List<TModel>();
        }

        public IEnumerable<TModel> Result { get; set; }

        public int TotalCount { get; set; }

        //public SearchyResponse ToSearchyResponse()
        //{
        //    return new SearchyResponse
        //    {
        //        TotalCount = TotalCount,
        //        Result = Result
        //    };
        //}

    }

    //public class SearchyResponse
    //{
    //    public SearchyResponse()
    //    {
    //    }

    //    public IEnumerable Result { get; set; }
    //    public int TotalCount { get; set; }

    //    public SearchyResponse<TModel> ToSearchyResponse<TModel>()
    //    {
    //        return new SearchyResponse<TModel>
    //        {
    //            TotalCount = TotalCount,
    //            Result = (IEnumerable<TModel>)Result
    //        };
    //    }
    //}
}
