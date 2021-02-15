using Sawubona.CleanerRobot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.ConsoleApp
{
    public class Controller
    {
        IDisplay _display;
        IReader _reader;
        IRobot _robot;
        public Controller(IDisplay display, IReader reader, IRobot robot)
        {
            _display = display;
            _reader = reader;
            _robot = robot;
        }

        public void Run()
        {
            CleanningSession session = _reader.ReadAllCommands();
            try
                {
                IDictionary<Coordinate, bool> placesClean = _robot.ExecuteClean(session);
                String uniqueCoordinates = String.Empty;
                String allCoordinates = String.Empty;
                foreach (var places in placesClean)
                {
                    var coordinateToPrint = places.Key.X + "," + places.Key.Y;
                    uniqueCoordinates = String.IsNullOrEmpty(uniqueCoordinates)? (uniqueCoordinates + coordinateToPrint) : (uniqueCoordinates + ";" + coordinateToPrint);
                }
                foreach (var places in session.coordinates)
                {
                    var coordinateToPrint = places.X + "," + places.Y;
                    allCoordinates = String.IsNullOrEmpty(allCoordinates) ? (allCoordinates + coordinateToPrint) : (allCoordinates + ";" + coordinateToPrint);
                }
                if (!String.IsNullOrEmpty(session.ErrorMessage))
                {
                    _display.WriteLine(string.Format(Resources.ErrorLabel, session.ErrorMessage));
                }
                if (!String.IsNullOrEmpty(allCoordinates))
                {
                    _display.WriteLine(string.Format(Resources.ResultLabel2));
                    _display.WriteLine(allCoordinates);
                }
                if (!String.IsNullOrEmpty(uniqueCoordinates))
                {
                    _display.WriteLine(string.Format(Resources.ResultLabel1));
                    _display.WriteLine(uniqueCoordinates);
                }
                _display.ReadLine();
            }
            catch (Exception ex)
            {
                _display.WriteLine(string.Format(Resources.ErrorLabel, ex.Message));
            }
        }

    }
}
