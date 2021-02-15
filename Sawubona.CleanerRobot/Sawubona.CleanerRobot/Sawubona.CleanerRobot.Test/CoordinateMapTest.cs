using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sawubona.CleanerRobot.Core;

namespace Sawubona.CleanerRobot.Test
{
    [TestFixture]
    public class CoordinateMapTest
    {

        [Test]
        public void GetDirectionStep_North_should_be_0_1()
        {
            Coordinate result = CoordinateMap.GetDirectionStep(Direction.N);

            Assert.AreEqual(0, result.X);
            Assert.AreEqual(1, result.Y);
        }

        [Test]
        public void GetDirectionStep_South_Should_Be_0_minus1()
        {
            Coordinate result = CoordinateMap.GetDirectionStep(Direction.S);
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(-1, result.Y);
        }

        [Test]
        public void GetDirectionStep_East_Should_Be_1_0()
        {
            Coordinate result = CoordinateMap.GetDirectionStep(Direction.E);
            Assert.AreEqual(1, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [Test]
        public void GetDirectionStep_West_Should_Be_minus1_0()
        {
            Coordinate result = CoordinateMap.GetDirectionStep(Direction.W);
            Assert.AreEqual(-1, result.X);
            Assert.AreEqual(0, result.Y);
        }
    }
}
