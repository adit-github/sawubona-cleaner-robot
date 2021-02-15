using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cint.CleanerRobot.Core;

namespace Cint.CleanerRobot.Test
{
    [TestClass]
    public class OfficeTest
    {
        [TestMethod]
        public void Clean_1_office_cleanedSpaces_should_be_1()
        {
            int expected = 1;
            Office office = new Office();
            office.Clean(new Coordinate(0, 0));
            Assert.AreEqual(expected, office.CleanSpaces);
        }

        [TestMethod]
        public void Clean_5_different_offices_cleanedSpaces_should_be_5()
        {

            int expected = 5;
            Office office = new Office();
            office.Clean(new Coordinate(0, 0));
            office.Clean(new Coordinate(100000, 100000));
            office.Clean(new Coordinate(-100000, 100000));
            office.Clean(new Coordinate(100000, -100000));
            office.Clean(new Coordinate(-100000, -100000));
            Assert.AreEqual(expected, office.CleanSpaces);
        }

        [TestMethod]
        public void Clean_repeated_offices_should_not_increase()
        {
            int expected = 4;
            Office office = new Office();
            office.Clean(new Coordinate(0, 0));
            office.Clean(new Coordinate(77, 77));
            office.Clean(new Coordinate(100000, 100000));
            office.Clean(new Coordinate(-100000, 100000));
            office.Clean(new Coordinate(77, 77));
            office.Clean(new Coordinate(-100000, 100000));
            Assert.AreEqual(expected, office.CleanSpaces);
        }

    }
}
