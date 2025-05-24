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
        [Description("линейная")]
        Linear,
        [Description("квадратичная")]
        Quadratic,
        [Description("кубическая")]
        Cubic,
        [Description("4-ой степени")]
        Degree4,
        [Description("5-ой степени")]
        Degree5
    }
}
