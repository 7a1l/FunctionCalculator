using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Calculators
{
    public class LinearFunctionCalculator : FunctionCalculatorBase
    {
        public LinearFunctionCalculator(double a, double b, double c) : base(a, b, c) { }

        public override double Calculate(double x, double y)
        {
            return A * x + B * Math.Pow(y, 0) + C;
        }
    }
}
