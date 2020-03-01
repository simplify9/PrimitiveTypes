using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IHandle<in T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}