using Sawubona.CleanerRobot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawubona.CleanerRobot.Core
{
    public class CleanningSession
    {
        private Coordinate _startingCoordinate;
        private List<MoveCommand> _commands;

        public IEnumerable<Coordinate> coordinates { get; set; }
        public string ErrorMessage { get; set; }
        public Coordinate StartingCoordinate { get { return _startingCoordinate; } }
        public List<MoveCommand> Commands { get { return _commands; } }
        public CleanningSession(Coordinate startingCoordinate, List<MoveCommand> commands)
        {
            this._startingCoordinate = startingCoordinate;
            this._commands = commands;
        }
    }
}
