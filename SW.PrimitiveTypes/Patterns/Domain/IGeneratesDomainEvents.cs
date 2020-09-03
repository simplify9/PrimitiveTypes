using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public interface IGeneratesDomainEvents
    {
        ICollection<IDomainEvent> Events { get; }
    }
}
