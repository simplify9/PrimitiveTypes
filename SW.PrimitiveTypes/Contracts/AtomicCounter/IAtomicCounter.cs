using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IAtomicCounter
    {
        Task<long> IncrementAsync(string counterName);

        Task ResetAsync(string counterName);

    }
}
