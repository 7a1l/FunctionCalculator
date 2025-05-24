using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{
    public class CubicFunctionCalculator : FunctionCalculatorBase
    {
        /// <summary>
        /// Калькулятор кубической функции: f(x, y) = a * x³ + b * y² + c.
        /// Используется для вычислений функции третьей степени.
        /// </summary>
        public CubicFunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * Math.Pow(x, 3) + B * Math.Pow(y, 2) + C;
        }
    }
}
