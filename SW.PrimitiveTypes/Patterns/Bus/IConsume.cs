using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IConsume
    {
        string ConsumerName { get; }
        Task<IEnumerable<string>> GetMessageTypeNames(); 
        Task Process(string messageTypeName, string message);
    }


}
