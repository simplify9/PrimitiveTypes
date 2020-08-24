using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes.Contracts.CqApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class UnprotectAttribute : Attribute {}
}
