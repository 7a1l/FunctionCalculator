using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{

    public class Degree5FunctionCalculator : FunctionCalculatorBase
    {
        /// <summary>
        /// Калькулятор функции пятой степени: f(x, y) = a * x⁵ + b * y⁴ + c.
        /// Используется для вычислений функции пятой степени.
        /// </summary>
        public Degree5FunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * Math.Pow(x, 5) + B * Math.Pow(y, 4) + C;
        }
    }
}
