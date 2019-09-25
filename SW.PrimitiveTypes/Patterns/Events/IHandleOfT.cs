using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IHandle<T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}