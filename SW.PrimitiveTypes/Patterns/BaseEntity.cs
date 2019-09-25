using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)


    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
        //public int Id { get; set; }

        //public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}