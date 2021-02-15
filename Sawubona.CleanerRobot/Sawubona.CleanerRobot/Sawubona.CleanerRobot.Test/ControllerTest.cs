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
    public class ControllerTest
    {
        Mock<IDisplay> _mockView;
        Mock<IReader> _mockReader;
        Mock<IRobot> _mockRobot;

        [SetUp]
        public void TestInit()
        {
            _mockView = new Mock<IDisplay>();
            _mockReader = new Mock<IReader>();
            _mockRobot = new Mock<IRobot>();
        }

        [Test]
        public void Run_should_display_places_cleaned()
        {
            Controller SUT = new Controller(_mockView.Object, _mockReader.Object, _mockRobot.Object);
            CleanningSession mockSession = new CleanningSession(new Coordinate(0, 0), new List<MoveCommand>());
            mockSession.coordinates = new List<Coordinate>();
            _mockReader.Setup(x => x.ReadAllCommands()).Returns(mockSession);
            Coordinate cordinate = new Coordinate(4,6);
            IDictionary<Coordinate, bool> placesClean = new Dictionary<Coordinate, bool>();
            placesClean[cordinate] = true;
            _mockRobot.Setup(x => x.ExecuteClean(It.IsAny<CleanningSession>())).Returns(placesClean);
            _mockView.Setup(x => x.WriteLine(It.IsAny<String>()));

            SUT.Run();

            _mockView.Verify(w => w.WriteLine(It.Is<string>(s => s == "4,6")));
        }

    }
}
