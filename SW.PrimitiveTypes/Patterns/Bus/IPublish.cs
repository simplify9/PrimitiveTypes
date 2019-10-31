using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IPublish
    {
        Task Publish<TMessage>(TMessage message);
        Task Publish(string messageTypeName, string message);
        Task Publish(string messageTypeName, byte[] message);

    }
}
