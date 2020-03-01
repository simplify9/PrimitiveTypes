using System;

namespace SW.PrimitiveTypes
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public DateTime On { get; } = DomainTime.Now();
    }
}