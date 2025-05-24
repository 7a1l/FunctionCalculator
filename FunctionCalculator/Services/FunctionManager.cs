using FunctionCalculator.Models;
using FunctionCalculator.Models.Interfaces;
using FunctionCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Services
{
    /// <summary>
    /// Управляет входными данными и расчетами функций.
    /// Хранит строки ввода и коэффициенты для каждого типа функции.
    /// Выполняет пересчёт результата при изменении данных.
    /// </summary>

    class FunctionManager
    {
        private readonly Dictionary<FunctionType, List<InputRow>> _rowsByType = new();
        private readonly Dictionary<FunctionType, (double a, double b, double c)> _coefficientsByType = new();
        private readonly IFunctionCalculatorFactory _calculatorFactory;

        /// <summary>
        /// Инициализирует менеджер с фабрикой калькуляторов.
        /// </summary>
        public FunctionManager(IFunctionCalculatorFactory calculatorFactory)
        {
            _calculatorFactory = calculatorFactory;
        }
        /// <summary>
        /// Устанавливает коэффициенты для выбранного типа функции.
        /// </summary>
        public void SetCoefficients(FunctionType type, double a, double b, double c)
        {
            _coefficientsByType[type] = (a, b, c);
        }

        /// <summary>
        /// Получает коэффициенты для указанного типа функции.
        /// </summary>
        public (double a, double b, double c) GetCoefficients(FunctionType type) 
        {
            return _coefficientsByType.TryGetValue(type, out var tuple) ? tuple : (0, 0, 0);
        }

        /// <summary>
        /// Устанавливает список входных строк и пересчитывает результат.
        /// </summary>
       
        public void SetRows(FunctionType type, List<InputRow> rows)
        {
            _rowsByType[type] = rows;
        }

        /// <summary>
        /// Получает список вводных строк для указанного типа функции.
        /// </summary>
        public List<InputRow> GetRows(FunctionType type)
        {
            return _rowsByType.TryGetValue(type, out var list) ? list : [];
        }

        /// <summary>
        /// Выполняет пересчёт результатов для всех строк указанного типа функции.
        /// </summary>
        public void Recalculate(FunctionType type)
        {
            if (!_rowsByType.ContainsKey(type) || !_coefficientsByType.ContainsKey(type))
            {
                return;
            } 
            var (a, b, c) = _coefficientsByType[type];
            var calculator = _calculatorFactory.Create(type, a, b, c);
            foreach ( var row in _rowsByType[type])
            {
                row.Result = calculator.Calculate(row.X, row.Y);
            }
        }
    }
}
