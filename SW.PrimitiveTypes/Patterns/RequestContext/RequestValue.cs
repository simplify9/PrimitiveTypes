using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestValue 
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

        public override bool Equals(object obj)
        {
            return obj is RequestValue value &&
                   Name == value.Name &&
                   Value == value.Value &&
                   Type == value.Type;
        }

        public override int GetHashCode()
        {
            int hashCode = 1477810893;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            return hashCode;
        }
    }
}
