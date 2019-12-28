using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class ResourceHanlderAttribute : Attribute
    {
        public ResourceHanlderAttribute()
        {
        }

        public ResourceHanlderAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; set; }
    }
}
