using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_5_1
{
    public class CalculatorManager : ICalculatorManager
    {
        public double Sum(double x, double y)
        {
            return x + y;
        }
    }
}
