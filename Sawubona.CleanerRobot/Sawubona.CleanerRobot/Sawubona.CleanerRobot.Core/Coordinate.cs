using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.Core
{
    public class Coordinate
    {
        public int Y
        {
            get { return _pair.Item2; }
        }

        public int X
        {
            get { return _pair.Item1; }
        }

        public int MaxX
        {
            get; set;
        }

        public int MinX
        {
            get; set;
        }

        public int MaxY
        {
            get; set;
        }

        public int MinY
        {
            get; set;
        }

        private Tuple<int, int> _pair;

        public Coordinate(int x, int y)
        {
            _pair = new Tuple<int, int>(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Coordinate coordinate = (Coordinate)obj;
            return this._pair.Equals(coordinate._pair);
        }

        public override int GetHashCode()
        {
            return _pair.GetHashCode();
        }

    }

}
