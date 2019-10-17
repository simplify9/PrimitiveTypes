using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IConsume
    {
        string ConsumerName { get; }
        string[] MessageTypeNames { get; }
        Task Process(string messageTypeName, string message);
    }


}
