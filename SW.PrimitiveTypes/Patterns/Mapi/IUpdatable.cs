using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IUpdatable<T> : IService
    {
        Task Update(string key, T model);
    }
}
