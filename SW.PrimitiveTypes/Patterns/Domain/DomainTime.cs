using System;

namespace SW.PrimitiveTypes
{
    public static class DomainTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}
