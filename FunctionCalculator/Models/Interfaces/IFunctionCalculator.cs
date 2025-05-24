using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для вычисления значения f(x, y) с заданными коэффициентами.
    /// </summary>
    public interface IFunctionCalculator
    {
        double Calculate(double x, double y);
    }
}
