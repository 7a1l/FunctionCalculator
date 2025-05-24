using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{
    public class Degree4FunctionCalculator : FunctionCalculatorBase
    {
        /// <summary>
        /// Калькулятор функции четвёртой степени: f(x, y) = a * x⁴ + b * y³ + c.
        /// Используется для вычислений функции четвёртой степени.
        /// </summary>
        public Degree4FunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * Math.Pow(x, 4) + B * Math.Pow(y, 3) + C;
        }
    }
}
