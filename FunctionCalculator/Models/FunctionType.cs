using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models
{

    /// <summary>
    /// Перечисление доступных математических функций.
    /// </summary>
    public enum FunctionType
    {
        Linear,
        Quadratic,
        Cubic,
        Degree4,
        Degree5
    }
}
