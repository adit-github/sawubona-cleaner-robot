using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawubona.CleanerRobot.ConsoleApp
{
    public interface IDisplay
    {
        string ReadLine();

        void WriteLine(string output);
    }
}
