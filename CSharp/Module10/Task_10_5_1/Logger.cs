using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_5_1
{
    public class Logger : ILogger
    {
        public void Error(string message)
        {
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine(message);
           Console.ForegroundColor = ConsoleColor.White;
        }

        public double Sum(double x, double y)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return x + y;
        }
    }
}
