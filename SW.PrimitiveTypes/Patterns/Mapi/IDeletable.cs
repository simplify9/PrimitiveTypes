using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IDeletable<T> : IService
    {
        Task Delete(string key);
    }
}
