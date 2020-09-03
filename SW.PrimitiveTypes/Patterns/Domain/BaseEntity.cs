using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public abstract class BaseEntity<TKey> : IAggregateRoot<TKey>
    {
        public TKey Id { get; set; }
        public ICollection<IDomainEvent> Events { get; } = new List<IDomainEvent>();
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}