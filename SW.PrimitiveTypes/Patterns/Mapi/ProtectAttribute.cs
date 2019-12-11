using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class ProtectAttribute : Attribute
    {
        public bool RequireRole { get; set; }
    }
}
