using System.Security.AccessControl;

namespace Task_10_5_1
{
    internal class Program
    {
        static ICalculatorManager CalculatorManager { get; set; }
        static void Main(string[] args)
        {
            CalculatorManager = new CalculatorManager();

            var calculator = new Calculator(CalculatorManager);

            calculator.Start();

        }
    }
}