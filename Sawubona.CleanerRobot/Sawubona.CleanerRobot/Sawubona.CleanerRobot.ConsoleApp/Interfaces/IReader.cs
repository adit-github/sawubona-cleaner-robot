using Sawubona.CleanerRobot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawubona.CleanerRobot.ConsoleApp
{
    public interface IReader
    {

        public string[] ReadFormattedInput();

        public Coordinate ReadStartingCoordinate(string startingPosition);

        public MoveCommand ReadDirection(string direction);

        public CleanningSession ReadAllCommands();
    }
}
