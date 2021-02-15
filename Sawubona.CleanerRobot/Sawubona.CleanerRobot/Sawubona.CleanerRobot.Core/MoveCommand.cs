using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawubona.CleanerRobot.Core
{
    public class MoveCommand
    {
        private Direction _direction;

        public Direction Direction
        {
            get { return _direction; }
        }

        private int _steps;
        public MoveCommand(Direction direction, int steps)
        {
            _direction = direction;
            _steps = steps;
        }

        public int Steps
        {
            get { return _steps; }
        }
        

    }
}
