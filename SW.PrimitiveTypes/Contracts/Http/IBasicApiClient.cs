using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IBasicApiClient
    {
        Task<ApiResult<SearchyResponse<TModel>>> Search<TModel>(string url);
        Task<ApiResult<IDictionary<string, string>>> Search(string url);
        Task<ApiResult<string>> Lookup(string url);
    }
}
