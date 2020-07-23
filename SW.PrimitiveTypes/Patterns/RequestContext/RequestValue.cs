using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestValue : ValueObject
    {
        public RequestValue(string name, string value, RequestValueType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Type = type;
        }

        public string Name { get;  }
        public string Value { get;  }
        public RequestValueType Type { get;  }
    }
}
