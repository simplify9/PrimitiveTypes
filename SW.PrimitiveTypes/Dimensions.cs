using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Dimensions
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public DimensionUnit Unit { get; set; }

    }

    public enum DimensionUnit
    {
        cm,
        M,
        @in
    }
}
