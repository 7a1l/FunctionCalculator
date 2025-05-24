using FunctionCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Models
{
    /// <summary>
    /// Представляет строку таблицы с входными значениями x, y и результатом f(x, y).
    /// </summary>
    class InputRow : INotifyPropertyChanged
    {
        #region Переменные
        private double _x;
        private double _y;
        private double _result;
        private readonly IFunctionCalculator _functionCalculator;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Свойства для привязки данных
        /// <summary>
        /// Значение X
        /// </summary>
        public double X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged();
                    Recalculate();
                }
            }
        }
        /// <summary>
        /// Значение Y
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged();
                    Recalculate();
                }
            }
        }
        /// <summary>
        /// Результат f(x, y) 
        /// </summary>
        public double Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Конструктор и инициализация
        public InputRow(IFunctionCalculator functionCalculator)
        {
            _functionCalculator = functionCalculator ?? throw new ArgumentNullException(nameof(functionCalculator));
        }

        public void Recalculate()
        {
            Result = _functionCalculator.Calculate(X, Y);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
