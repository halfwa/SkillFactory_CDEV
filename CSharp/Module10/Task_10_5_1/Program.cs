using System.Security.AccessControl;

namespace Task_10_5_1 
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();

            var calculator = new Calculator(Logger);

            calculator.Start();

        }
    }
}