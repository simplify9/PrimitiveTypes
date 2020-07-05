
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}