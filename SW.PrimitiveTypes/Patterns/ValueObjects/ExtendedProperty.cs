using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public enum ExtendedPropertyType
    {
        Text = 0,
        Boolean = 1,
        Integer = 20,
        Decimal = 30,
        DateTime = 40,
    }

    public class ExtendedProperty
    {
        public ExtendedProperty()
        {
        }

        public string Name { get; set; }
        public ExtendedPropertyType Type { get; set; }
        public bool Required { get; set; }
        public Lookup  Lookup { get; set; }
    }

}
