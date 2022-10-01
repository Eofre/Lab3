using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass()]
    public class TemperatureTests
    {
        [TestMethod()]
        public void SubNumberTest()
        {
            var temperature = new Temperature(10, MeasureType.C);
            temperature = temperature - 1;
            Assert.AreEqual("9 C", temperature.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var temperature = new Temperature(10, MeasureType.C);
            temperature = temperature * 2;
            Assert.AreEqual("20 C", temperature.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var temperature = new Temperature(10, MeasureType.C);
            temperature = temperature / 2;
            Assert.AreEqual("5 C", temperature.Verbose());
        }

        [TestMethod()]
        public void CelsiusToAnyTest()
        {
            Temperature temperature;

            temperature = new Temperature(10, MeasureType.C);
            Assert.AreEqual("283,15 K", temperature.To(MeasureType.K).Verbose());

            temperature = new Temperature(400, MeasureType.C);
            Assert.AreEqual("752 F", temperature.To(MeasureType.F).Verbose());

            temperature = new Temperature(22, MeasureType.C);
            Assert.AreEqual("295,15 R", temperature.To(MeasureType.R).Verbose());
        }

        [TestMethod()]
        public void AnyToCelsiusTest()
        {
            Temperature temperature;

            temperature = new Temperature(283.15, MeasureType.K);
            Assert.AreEqual("10 C", temperature.To(MeasureType.C).Verbose());

            temperature = new Temperature(752, MeasureType.F);
            Assert.AreEqual("400 C", temperature.To(MeasureType.C).Verbose());

            temperature = new Temperature(531.27, MeasureType.R);
            Assert.AreEqual("21,78 C", temperature.To(MeasureType.C).Verbose());
        }

        [TestMethod()]
        public void AddSubKelvinCelsiusTest()
        {
            var C = new Temperature(15, MeasureType.C);
            var K = new Temperature(278.15, MeasureType.K);

            Assert.AreEqual("20 C", (C + K).Verbose());
            Assert.AreEqual("566,3 K", (K + C).Verbose());

            Assert.AreEqual("10 C", (C - K).Verbose());
            Assert.AreEqual("-10 K", (K - C).Verbose());
        }
    }
}