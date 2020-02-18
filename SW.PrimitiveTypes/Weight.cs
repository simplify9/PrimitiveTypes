using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Weight : IEquatable<Weight>
    {
        public decimal? Value { get; set; }

        public WeightUnit? Unit { get; set; }

        public static Weight Empty()
        {
            return new Weight { };
        }

        //public static Weight Zero
        //{
        //    get
        //    {
        //        return new Weight(0, WeightUnit.g);
        //    }
        //}
        
        //public Weight ChangeUnit(DimensionUnit toUnit)
        //{
        //    throw new NotImplementedException();
        //}

        public  Weight()
        {

        }

        public Weight(Weight another)
        {
            Value = another.Value;
            Unit = another.Unit;
        }


        public Weight(decimal value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }
        
        public override bool Equals(object another)
        {
            if (another == null) return false;
            var weight = another as Weight;
            if (weight == null) return false;
            return Value == weight.Value && Unit == weight.Unit;
        }

        public override string ToString()
        {
            return Value == null? "[Empty]" : string.Format("{0:0.###}{1}", Value, Unit);
        }

        public bool Equals(Weight other)
        {
            return other != null &&
                   Value == other.Value &&
                   Unit == other.Unit;
        }

        public override int GetHashCode()
        {
            var hashCode = -177567199;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Unit.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Weight weight1, Weight weight2)
        {
            return EqualityComparer<Weight>.Default.Equals(weight1, weight2);
        }

        public static bool operator !=(Weight weight1, Weight weight2)
        {
            return !(weight1 == weight2);
        }
    }

    public enum WeightUnit
    {
        gm,
        kg,
        lb,
        oz
    }

}
