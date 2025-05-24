using FunctionCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models
{
    /// <summary>
    /// Фабрика для создания объектов IFunctionCalculator по типу функции.
    /// </summary>
    class FunctionCalculatorFactory
    {
        public static IFunctionCalculator create(FunctionType type, double a, double b, double c)
        {
            return type switch
            {
                FunctionType.Linear => new LinearFunctionCalculator(a, b, c),
                FunctionType.Quadratic => new QuadraticFunctionCalculator(a, b, c),
                FunctionType.Cubic => new CubicFunctionCalculator(a, b, c),
                FunctionType.Degree4 => new Degree4FunctionCalculator(a, b, c),
                FunctionType.Degree5 => new Degree5FunctionCalculator(a, b, c),
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Неизвестный тип функции {type}")
            };
        }
    }
}
