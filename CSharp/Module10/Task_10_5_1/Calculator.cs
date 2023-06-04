using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_5_1
{
    internal class Calculator : ICalculator
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }
        public void Start()
        {
            Console.WriteLine("Калькулятор работает!");
            bool isActive = true;
            while (isActive)
            {
                try
                {
                    double num1, num2, result = 0;

                    Console.WriteLine("Введите два числа для получения их суммы...");
                    Console.WriteLine("Первое число :");
                    num1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Второе число :");
                    num2 = double.Parse(Console.ReadLine());

                    result = Logger.Sum(num1, num2);
                    Console.WriteLine($"{num1} + {num2} = {result}");
                    isActive = false;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    
    }
}
