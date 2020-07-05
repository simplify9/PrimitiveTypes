using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public static class DimensionConvert
    {
        public static decimal FromCmToM(decimal val) => val / 100m;
        public static decimal FromMToCm(decimal val) => val * 100m;
        public static decimal FromCmToIn(decimal val) => val / 2.54m;
        public static decimal FromInToCm(decimal val) => val * 2.54m;
        public static decimal FromMToIn(decimal val) => val * 39.37m;
        public static decimal FromInToM(decimal val) => val / 39.37m;
    }
}
