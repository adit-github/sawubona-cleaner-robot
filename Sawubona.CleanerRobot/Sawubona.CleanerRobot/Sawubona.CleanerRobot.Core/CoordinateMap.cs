using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.Core
{

    public enum Direction
    {
        N,
        S,
        W,
        E
    }

    public class CoordinateMap
    {

        public static Coordinate GetDirectionStep(Direction direction)
        {
            return _mapDirectionCoordinate[direction];
        }

        private static Dictionary<Direction, Coordinate> _mapDirectionCoordinate = new Dictionary<Direction, Coordinate>
        {
	        {Direction.N, new Coordinate(0, 1)},
	        {Direction.S, new Coordinate(0, -1)},
            {Direction.E, new Coordinate(1, 0)},
            {Direction.W, new Coordinate(-1, 0)}
        };

        private static Dictionary<String, Direction> _mapDirectionName = new Dictionary<String, Direction>
        {
	        {"N", Direction.N},
	        {"S", Direction.S},
            {"E", Direction.E},
            {"W", Direction.W}
        };

        public static Direction GetDirection(string p)
        {
            return _mapDirectionName[p];
        }
    }
}
