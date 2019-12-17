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
            var dim = new Dimensions(300, 400, 500, DimensionUnit.cm);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Length, 3m);
            Assert.AreEqual(dimInM.Width, 4m);
            Assert.AreEqual(dimInM.Height, 5m);
        }

        [TestMethod]
        public void FromMToCm()
        {
            var dim = new Dimensions(2, 3, 4, DimensionUnit.M);
            var dimInCm = dim.Convert(DimensionUnit.cm);

            Assert.AreEqual(dimInCm.Length, 200);
            Assert.AreEqual(dimInCm.Width, 300);
            Assert.AreEqual(dimInCm.Height, 400);
        }

        [TestMethod]
        public void FromInToCm()
        {
            var dim = new Dimensions(2, 3, 4, DimensionUnit.@in);
            var dimInCm = dim.Convert(DimensionUnit.cm);

            Assert.AreEqual(dimInCm.Length,5.08m);
            Assert.AreEqual(dimInCm.Width, 7.62m);
            Assert.AreEqual(dimInCm.Height, 10.16m);
        }

        [TestMethod]
        public void FromCmToIn()
        {
            var dim = new Dimensions(10, 20, 30, DimensionUnit.cm);
            var dimInIn = dim.Convert(DimensionUnit.@in);

            Assert.AreEqual(dimInIn.Length, 3.937008m);
            Assert.AreEqual(dimInIn.Width, 7.874016m);
            Assert.AreEqual(dimInIn.Height, 11.811024m);
        }
        
        [TestMethod]
        public void FromInToM()
        {
            var dim = new Dimensions(200, 300, 400, DimensionUnit.@in);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Length, 5.08001m);
            Assert.AreEqual(dimInM.Width, 7.620015m);
            Assert.AreEqual(dimInM.Height, 10.160020m);
        }

        [TestMethod]
        public void FromMToIn()
        {
            var dim = new Dimensions(5, 10, 15, DimensionUnit.M);
            var dimInIn = dim.Convert(DimensionUnit.@in);

            Assert.AreEqual(dimInIn.Length, 196.85m);
            Assert.AreEqual(dimInIn.Width, 393.7m);
            Assert.AreEqual(dimInIn.Height, 590.55m);
        }

        [TestMethod]
        public void FromToSame()
        {
            var dim = new Dimensions(5, 15, 30, DimensionUnit.M);
            var dimInM = dim.Convert(DimensionUnit.M);

            Assert.AreEqual(dimInM.Length, 5m);
            Assert.AreEqual(dimInM.Width, 15m);
            Assert.AreEqual(dimInM.Height, 30m);
            Assert.AreEqual(dimInM.Unit, DimensionUnit.M);
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
