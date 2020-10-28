using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IAtomicCounter
    {
        Task<long> IncrementAsync(string counterName, long increment = 1);

        Task ResetAsync(string counterName);

    }
}
