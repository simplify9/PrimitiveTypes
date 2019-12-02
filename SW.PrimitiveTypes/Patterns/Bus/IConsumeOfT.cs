using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IConsume<TMessage> : IConsumeBase where TMessage : class
    {
        Task Process(TMessage message);
    }
}
