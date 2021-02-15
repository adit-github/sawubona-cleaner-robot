using Sawubona.CleanerRobot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawubona.CleanerRobot.ConsoleApp
{
    public class Reader : IReader
    {
        IDisplay _view;
        public Reader(IDisplay view)
        {
            _view = view;
        }
        public string[] ReadFormattedInput()
        {
            string line = _view.ReadLine();
            string[] splitedCommands = line.Split(';');
            return splitedCommands;
        }

        public Coordinate ReadStartingCoordinate(string startingPosition)
        {
            string[] coordinates = startingPosition.Split(',');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            return new Core.Coordinate(x, y);
        }

        private void SetMapBoundaries(Coordinate startingPosition, string mapLimit)
        {
            string[] details = mapLimit.Split(',');
            startingPosition.MinX = int.Parse(details[0]);
            startingPosition.MaxX = int.Parse(details[1]);
            startingPosition.MinY = int.Parse(details[2]);
            startingPosition.MaxY = int.Parse(details[3]);
        }
        public  MoveCommand ReadDirection(string direction)
        {
            return new MoveCommand(CoordinateMap.GetDirection(direction[0].ToString()), int.Parse(direction[1].ToString()));
        }
        public CleanningSession ReadAllCommands()
        {
            string mapLimit = String.Empty;
            String startingPosition = String.Empty;
            string directions = String.Empty;
            string[] splittedCommands = this.ReadFormattedInput();
            if (splittedCommands != null && splittedCommands.Count() == 3)
            {
                foreach (var splitedCommand in splittedCommands)
                {
                    if (splitedCommand.StartsWith("M"))
                    {
                        mapLimit = splitedCommand.Substring(2, splitedCommand.Length - 2);
                    }
                    else if (splitedCommand.StartsWith("S"))
                    {
                        startingPosition = splitedCommand.Substring(2, splitedCommand.Length - 2);
                    }
                    else 
                    {
                        directions = splitedCommand.Substring(1, splitedCommand.Length - 2);
                    }
                }
            }
            else
            {
                CleanningSession emptySession = new CleanningSession(new Coordinate(0,0), new List<MoveCommand>());
                emptySession.ErrorMessage = "Input data is not in a correct format";
                return emptySession;
            }

            Coordinate startingCoordinate = this.ReadStartingCoordinate(startingPosition);
            SetMapBoundaries(startingCoordinate, mapLimit);
            List<MoveCommand> commands = new List<MoveCommand>();
            string[] details = directions.Split(',');
            foreach (var direction in details)
            { 
                commands.Add(this.ReadDirection(direction));
            }
            CleanningSession session = new CleanningSession(startingCoordinate, commands);
            return session;
        }
    }
}
