using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IGettable<T> : IService
    {
        Task<T> Get(string key);
    }
}
