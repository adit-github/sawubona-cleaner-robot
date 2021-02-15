using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sawubona.CleanerRobot.Core;

namespace Sawubona.CleanerRobot.Test.CoordinateTest
{
    [TestFixture]
    public class CoordinateTest
    {
        [Test]
        public void Equals_different_instances_same_parameters_should_be_true()
        {
            Coordinate coordinate = new Coordinate(10, 15);
            Coordinate coordinate2 = new Coordinate(10, 15);
            bool result = coordinate.Equals(coordinate2);
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_different_parameters_should_be_false()
        {
            Coordinate coordinate = new Coordinate(10, 15);
            Coordinate coordinate2 = new Coordinate(100, 150);
            bool result = coordinate.Equals(coordinate2);
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_null_should_be_false()
        {
            Coordinate coordinate = new Coordinate(10, 15);
            bool result = coordinate.Equals(null);
            Assert.IsFalse(result);
        }

    }
}
