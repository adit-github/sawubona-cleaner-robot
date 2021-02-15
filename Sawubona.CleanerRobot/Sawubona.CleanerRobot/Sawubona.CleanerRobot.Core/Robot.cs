using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.Core
{
    public class Robot : IRobot
    {
        private Coordinate _currentPosition;
        private Dictionary<Coordinate, bool> _cleanOffices;

        public Coordinate CurrentPosition
        {
            get { return _currentPosition; }
            private set
            {
                _currentPosition = value;
                CleanCurrentPosition();
            }
        }

        public IList<Coordinate> coordinates { get; set; }

        public Robot()
        {
            coordinates = new List<Coordinate>();
            _cleanOffices = new Dictionary<Coordinate, bool>();
        }

        public void JumpTo(Coordinate position)
        {
            CurrentPosition = position;
        }

        private void CleanCurrentPosition()
        {
            coordinates.Add(_currentPosition);
            _cleanOffices[_currentPosition] = true;
        }

        public void MoveTowards(Direction direction, int steps)
        {
            Coordinate directionStep = CoordinateMap.GetDirectionStep(direction);
            for (int i = 0; i < steps; i++)
            {
                CurrentPosition = new Coordinate(_currentPosition.X + directionStep.X, _currentPosition.Y + directionStep.Y);
            }
        }

        public IDictionary<Coordinate, bool> ExecuteClean(CleanningSession session)
        {
            JumpTo(session.StartingCoordinate);
            foreach (var command in session.Commands)
            {
                Coordinate directionStep = CoordinateMap.GetDirectionStep(command.Direction);
                var newXCoordinate = _currentPosition.X + directionStep.X;
                var newYCoordinate = _currentPosition.Y + directionStep.Y;
                Boolean coordinateInBoundary = session.StartingCoordinate.MinX <= newXCoordinate && newXCoordinate <= session.StartingCoordinate.MaxX &&
                   session.StartingCoordinate.MinY <= newYCoordinate && newYCoordinate <= session.StartingCoordinate.MaxY;
                if (coordinateInBoundary)
                {
                    this.MoveTowards(command.Direction, command.Steps);
                }
                else 
                {
                    session.ErrorMessage = String.Format("Robot can't move outside the boundaries for coordinate {0}{1}", newXCoordinate, newYCoordinate);
                    break;
                }
            }
            session.coordinates = coordinates;
            return _cleanOffices;
        }
    }
}
