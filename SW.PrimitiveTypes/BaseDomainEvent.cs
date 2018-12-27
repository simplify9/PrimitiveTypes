using System;

namespace SW.Pmm.Primitives
{
    public abstract class BaseDomainEvent
    {
        public DateTime On { get; protected set; } = DateTime.UtcNow;
    }
}