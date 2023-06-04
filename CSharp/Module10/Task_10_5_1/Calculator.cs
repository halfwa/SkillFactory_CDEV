using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_5_1
{
    internal class Calculator : ICalculator
    {
        ICalculatorManager CalculatorManager { get; }
        public Calculator(ICalculatorManager calculatorManager)
        {
            CalculatorManager = calculatorManager;
        }
        public void Start()
        {
            Console.WriteLine("Калькулятор работает!");
            try
            {
                double num1, num2, result = 0;

                Console.WriteLine("Введите два числа для получения их суммы...");
                Console.WriteLine("Первое число :");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Второе число :");
                num2 = double.Parse(Console.ReadLine());

                result = CalculatorManager.Sum(num1, num2);

                Console.WriteLine($"{num1} + {num2} = {result}");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    
    }
}
