using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{
    public class LinearFunctionCalculator : FunctionCalculatorBase
    {
        /// <summary>
        /// Калькулятор линейной функции: f(x, y) = a * x + b * y⁰ + c.
        /// Используется для вычислений функции первой степени.
        /// </summary>
        public LinearFunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * x + B * 1 + C;
        }
    }
}
