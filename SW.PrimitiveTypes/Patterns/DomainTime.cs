using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public static class DomainTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}
