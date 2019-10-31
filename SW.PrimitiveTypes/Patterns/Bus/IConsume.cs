using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IConsume
    {
        string ConsumerName { get; }
        IEnumerable<string> MessageTypeNames { get; }
        Task Process(string messageTypeName, string message);
    }


}
