using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SW.PrimitiveTypes.UnitTests
{
    [TestClass]
    public class DimensionConversionTests
    {
        [TestMethod]
        public void FromCmToM()
        {
            var dim = new Dimensions(300, 300, 300, DimensionUnit.cm);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Height, 3m);
        }

        [TestMethod]
        public void FromMToCm()
        {
            var dim = new Dimensions(2, 2, 2, DimensionUnit.M);
            var dimInCm = dim.Convert(DimensionUnit.cm);

            Assert.AreEqual(dimInCm.Height, 200);
        }

        [TestMethod]
        public void FromInToCm()
        {
            var dim = new Dimensions(2, 2, 2, DimensionUnit.@in);
            var dimInCm = dim.Convert(DimensionUnit.cm);

            Assert.AreEqual(dimInCm.Height,5.08m);
        }

        [TestMethod]
        public void FromCmToIn()
        {
            var dim = new Dimensions(10, 10, 10, DimensionUnit.cm);
            var dimInIn = dim.Convert(DimensionUnit.@in);

            Assert.AreEqual(dimInIn.Height, 3.937008m);
        }
        
        [TestMethod]
        public void FromInToM()
        {
            var dim = new Dimensions(200, 200, 200, DimensionUnit.@in);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Height, 5.08001m);
        }

        [TestMethod]
        public void FromMToIn()
        {
            var dim = new Dimensions(5, 5, 5, DimensionUnit.M);
            var dimInIn = dim.Convert(DimensionUnit.@in);

            Assert.AreEqual(dimInIn.Height, 196.85m);
        }

        [TestMethod]
        public void FromToSame()
        {
            var dim = new Dimensions(5, 5, 5, DimensionUnit.M);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Height, 5m);
        }

        [TestMethod]
        public void VolumetricWeightCalculation()
        {
            var dimInM = new Dimensions(5, 5, 5, DimensionUnit.M);
            var volumetricWeight = dimInM.GetVolumetricWeight();

            Assert.AreEqual(volumetricWeight.Unit, WeightUnit.kg);
            Assert.AreEqual(volumetricWeight.Value, 250m);


            var dimInCm = new Dimensions(10, 10, 5, DimensionUnit.cm);
            volumetricWeight = dimInCm.GetVolumetricWeight();

            Assert.AreEqual(volumetricWeight.Unit, WeightUnit.kg);
            Assert.AreEqual(volumetricWeight.Value, 0.1m);

            var dimInIn = new Dimensions(10, 10, 5, DimensionUnit.@in);
            volumetricWeight = dimInIn.GetVolumetricWeight();

            Assert.AreEqual(volumetricWeight.Unit, WeightUnit.lb);
            Assert.AreEqual(volumetricWeight.Value, 3.613356m);
        }
    }
}
