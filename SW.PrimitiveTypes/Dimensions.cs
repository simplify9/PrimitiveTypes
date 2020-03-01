﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
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

        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }

        public DimensionUnit? Unit { get; set; }

        public decimal? Volume => Length == null ? (decimal?)null : Length.Value * Width.Value * Height.Value;


        public Weight GetVolumetricWeight(decimal? calculationFactor = null)
        {

            decimal factor;
            
            WeightUnit weightUnit; 
            //6000 ccm / kg, 166 cu in/ lb, 366 cu in/ kg
            switch (Unit)
            {
                case DimensionUnit.cm:
                    factor = 5000m;
                    weightUnit = WeightUnit.kg;
                    break;
                case DimensionUnit.M:
                    weightUnit = WeightUnit.kg;
                    factor = 0.5m;
                    break;
                case DimensionUnit.@in:
                    weightUnit = WeightUnit.lb;                    
                    factor = 138.3755m;
                    break;
                default:
                    throw new NotSupportedException();
            }

            
            var volumetricWeight = Math.Round(Volume.Value / (calculationFactor ?? factor), 6);
            return new Weight(volumetricWeight, weightUnit);
        }

        public bool IsValid()
        {
            if (Height == null || Width ==null || Length == null || Unit == null) return false;
            return true;
        }

        public Dimensions Convert(DimensionUnit toUnit)
        {
            if (!IsValid()) return null;

            return new Dimensions(Convert(toUnit, Length.Value),
                Convert(toUnit, Width.Value),
                Convert(toUnit, Height.Value),
                toUnit);
        }

        private decimal Convert(DimensionUnit toUnit, decimal val)
        {
            if (toUnit == Unit)
                return val;

            decimal result;
            switch (Unit)
            {
                case DimensionUnit.cm:
                    result = toUnit == DimensionUnit.M ? DimensionConvert.FromCmToM(val) :
                        DimensionConvert.FromCmToIn(val);
                    break;
                case DimensionUnit.M:
                    result = toUnit == DimensionUnit.cm ? DimensionConvert.FromMToCm(val) :
                        DimensionConvert.FromMToIn(val);
                    break;
                case DimensionUnit.@in:
                    result = toUnit == DimensionUnit.M ? DimensionConvert.FromInToM(val) :
                        DimensionConvert.FromInToCm(val);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return Math.Round(result, 6);
        }

        public override string ToString()
        {
            if (!IsValid()) return string.Empty;

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
