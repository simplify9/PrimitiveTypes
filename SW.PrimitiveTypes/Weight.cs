using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Weight
    {
        public decimal Value { get; set; }
        public WeightUnit Unit { get; set; }
    }

    public enum WeightUnit
    {
        g,
        Kg,
        Lb
    }

}
