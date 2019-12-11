using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ICreatable<T> : IService
    {
        Task<string> Create(T model);
    }
}
