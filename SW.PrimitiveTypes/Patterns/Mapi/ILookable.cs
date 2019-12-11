using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface  ILookable<T> : IService
    {
        Task<IDictionary<string, string>> LookupList(string phrase = null, SearchyRequest searchyRequest = null);
        Task<string> LookupValue(string key);
    }
}
