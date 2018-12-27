using System;

namespace SW.PrimitiveTypes
{
    public abstract class BaseDomainEvent
    {
        public DateTime On { get; protected set; } = DateTime.UtcNow;
    }
}