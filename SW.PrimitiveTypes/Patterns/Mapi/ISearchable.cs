using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ISearchable< T> : IService
    {
        Task<IEnumerable<ISearchyFilterSetup>> GetFilterSetup();
        Task<ISearchyResponse<T>> Search(SearchyRequest searchyRequest);
    }
}
