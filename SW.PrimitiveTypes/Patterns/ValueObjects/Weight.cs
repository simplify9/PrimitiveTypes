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

        public Weight()
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

        public bool IsValid()
        {
            if (Value == null || Unit == null) return false;
            return true;
        }

        public Weight Convert(WeightUnit weightUnit)
        {
            if (!IsValid()) return null;

            decimal valueInGrams = 0;

            switch (Unit)
            {
                case WeightUnit.gm:
                    valueInGrams = Value.Value;
                    break;
                case WeightUnit.kg:
                    valueInGrams = Value.Value * 1000m;
                    break;
                case WeightUnit.lb:
                    valueInGrams = Value.Value * 453.592m;
                    break;
                case WeightUnit.oz:
                    valueInGrams = Value.Value * 28.3495m;
                    break;
            }

            switch (weightUnit)
            {
                case WeightUnit.gm:
                    return new Weight(valueInGrams, weightUnit);
                case WeightUnit.kg:
                    return new Weight(valueInGrams / 1000m, weightUnit);
                case WeightUnit.lb:
                    return new Weight(valueInGrams / 453.592m, weightUnit);
                case WeightUnit.oz:
                    return new Weight(valueInGrams / 28.3495m, weightUnit);
            }

            return null;
        }

        public override string ToString()
        {
            if (!IsValid()) return string.Empty;

            return string.Format("{0:0.###}{1}", Value, Unit);
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
