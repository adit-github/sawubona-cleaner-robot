using Sawubona.CleanerRobot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sawubona.CleanerRobot.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            IDisplay display = new Display();
            IReader reader = new Reader(display);
            IRobot robot = new Robot();
            Controller controller = new Controller(display, reader, robot);
            controller.Run();
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
