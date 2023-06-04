using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10_5_1
{
    internal interface ILogger
    {
        public double Sum(double x, double y);
        void Error(string message);
    }
}
