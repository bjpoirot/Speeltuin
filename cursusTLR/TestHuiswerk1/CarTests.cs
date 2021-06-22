using NUnit.Framework;
using Huiswerk1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huiswerk1.Tests
{
    [TestFixture()]
    public class CarTests
    {
        [Test()]
        public void DieselCarTest()
        {
            var car = new DieselCar();
            var startCar = car.Start();
            Assert.AreEqual(startCar,"prut");
        }

        [Test()]
        public void PetrolCarTest()
        {
            var car = new PetrolCar();
            var startCar = car.Start();
            Assert.AreEqual(startCar, "vroom");
        }

        [Test()]
        public void ElectricCarTest()
        {
            var car = new ElectricCar();
            var startCar = car.Start();
            Assert.AreEqual(startCar, "zoom");
        }
    }
}