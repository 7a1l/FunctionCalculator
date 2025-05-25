using FunctionCalculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FunctionCalculator.Helpers
{
    public class FunctionTypeToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FunctionType ft)
            {
                return GetDisplayName(ft);
            }
            return value?.ToString() ?? "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static string GetDisplayName(FunctionType type)
        {
            return type switch
            {
                FunctionType.Linear => "Линейная",
                FunctionType.Quadratic => "Квадратичная",
                FunctionType.Cubic => "Кубическая",
                FunctionType.Degree4 => "4-ой степени",
                FunctionType.Degree5 => "5-ой степени",
                _ => type.ToString()
            };
        }

    }
}
