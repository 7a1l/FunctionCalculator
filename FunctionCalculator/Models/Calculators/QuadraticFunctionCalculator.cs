using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{
    public class QuadraticFunctionCalculator : FunctionCalculatorBase
    {
        /// <summary>
        /// Калькулятор квадратичной функции: f(x, y) = a * x² + b * y¹ + c.
        /// Используется для вычислений функции второй степени.
        /// </summary>
        public QuadraticFunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * Math.Pow(x, 2) + B * y + C;
        }
    }
}
