using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Helpers
{
    /// <summary>
    /// Класс для валидации входных значений (X и Y).
    /// </summary>
    public static class InputValidator
    {
        public static bool TryValidateDouble(string input, out double value)
        {
            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }
        public static string ValidateInput(string input, string field)
        {
            if (!TryValidateDouble(input, out _))
            {
                return $"{field} должно быть числом";
            }
            return null;
        }
    }
}
