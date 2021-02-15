using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.Core
{
    public interface IRobot
    {
        IDictionary<Coordinate, bool> ExecuteClean(CleanningSession session);
    }
}
