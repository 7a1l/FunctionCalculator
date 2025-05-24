using FunctionCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models
{
    /// <summary>
    /// Базовый абстрактный класс с коэффициентами a, b, c.
    /// </summary>
    public abstract class FunctionCalculatorBase : IFunctionCalculator
    {
        protected readonly double A;
        protected readonly double B;    
        protected readonly double C;
        protected FunctionCalculatorBase(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public abstract double Calculate(double x, double y);
    }
}
