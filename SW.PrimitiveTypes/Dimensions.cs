using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Pmm.Primitives
{
    public class Dimensions
    {
        public static Dimensions Empty()
        {
            return new Dimensions { };
        }

        public Dimensions()
        {

        }

        public Dimensions(decimal length, decimal width, decimal height, DimensionUnit unit)
        {
            Length = length;
            Width = width;
            Height = height;
            Unit = unit;
        }

        public decimal? Length { get; private set; }
        public decimal? Width { get; private set; }
        public decimal? Height { get; private set; }

        public DimensionUnit Unit { get; private set; }
        


        public Weight GetVolumetricWeight()
        {
            if (Length == null)
            {
                throw new InvalidOperationException("Cannot calculate the volumetric weight from empty dimensions");
            }

            var volume = Length.Value * Width.Value * Height.Value;

            //6000 ccm / kg, 166 cu in/ lb, 366 cu in/ kg
            switch (Unit)
            {
                case DimensionUnit.cm:
                    return new Weight(volume / 6000, WeightUnit.Kg);

                case DimensionUnit.M:
                    return new Weight(1000 * volume / 6000, WeightUnit.Kg);

                case DimensionUnit.@in:
                    return new Weight(volume / 166, WeightUnit.Lb);

                default:
                    throw new NotSupportedException();
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0:0.###}{1} X {2:0.###}{3} X {4:0.###}{5}", 
                Length, 
                Unit, 
                Width,
                Unit,
                Height,
                Unit);
        }
    }

    public enum DimensionUnit
    {
        cm,
        M,
        @in
    }
}
