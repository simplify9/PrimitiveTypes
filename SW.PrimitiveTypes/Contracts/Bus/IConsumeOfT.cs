using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IConsumeGenericBase { }

    public interface IConsume<TMessage> : IConsumeGenericBase where TMessage : class
    {
        Task Process(TMessage message);
    }
}
