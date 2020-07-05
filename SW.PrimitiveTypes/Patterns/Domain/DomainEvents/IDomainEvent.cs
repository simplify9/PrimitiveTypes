using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface IDomainEvent
    {
        DateTime On
        {
            get;
        }
    }
}
