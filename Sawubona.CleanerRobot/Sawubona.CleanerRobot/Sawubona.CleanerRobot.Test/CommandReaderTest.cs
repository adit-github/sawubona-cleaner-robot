using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Sawubona.CleanerRobot.Core;
using NUnit.Framework;
using Moq;
using Sawubona.CleanerRobot.ConsoleApp;

namespace Sawubona.CleanerRobot.Test
{
    [TestFixture]
    public class CommandReaderTest
    {
        Mock<IDisplay> _mockView;

        [SetUp]
        public void TestInit()
        {
            _mockView = new Mock<IDisplay>();
        }

        [Test]
        public void ReadAllCommands__should_return_cleaning_session()
        {
            Reader SUT = new Reader(_mockView.Object);
            _mockView.Setup(x => x.ReadLine()).Returns("[W1,N1,E1,E1,S1,S1,W1,W1,N1,E1];S:0,0;M:-1,1,-1,1");
            var result = SUT.ReadAllCommands();

            Assert.IsInstanceOf<CleanningSession>(result);
        }

        [Test]
        public void ReadStartingCoordinate_pair_integer_input_should_return_Coordinate()
        {
            Reader SUT = new Reader(_mockView.Object);
            Coordinate result = SUT.ReadStartingCoordinate("0,0");

            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [Test]
        public void ReadDirection_text_input_should_return_MoveCommand()
        {
            Reader SUT = new Reader(_mockView.Object);
            MoveCommand result = SUT.ReadDirection("E1");

            Assert.AreEqual(Direction.E, result.Direction);
            Assert.AreEqual(1, result.Steps);
        }        
    }
}
