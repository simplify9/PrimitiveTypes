using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}