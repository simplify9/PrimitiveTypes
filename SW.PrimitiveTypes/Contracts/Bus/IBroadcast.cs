using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IBroadcast
    {
        Task Broadcast<TMessage>(TMessage message);
        Task RefreshConsumers();
    }    
}
