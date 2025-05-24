using FunctionCalculator.Helpers;
using FunctionCalculator.Models;
using FunctionCalculator.Services;
using FunctionCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FunctionCalculator.ViewModels
{
    /// <summary>
    /// ViewModel для главного окна, содержит состояние приложения и логику взаимодействия с UI.
    /// </summary>
    class MainViewModel : INotifyPropertyChanged
    {
        #region Переменные
        private readonly FunctionManager _functionManager;
        private FunctionType _selectedFunction;
        private IFunctionCalculatorFactory _calculatorFactory;
        public event PropertyChangedEventHandler PropertyChanged;
        private double _a;
        private double _b;
        private double _c;
        #endregion

        #region Команды
        public ICommand AddRowCommand { get; }
        #endregion

        #region Свойства для привязки данных
        /// <summary>
        /// Коллекция доступных функций
        /// </summary>
        public ObservableCollection<FunctionType> Functions { get; }

        public FunctionType SelectedFunction
        {
            get => _selectedFunction;
            set
            {
                if (_selectedFunction != value)
                {
                    SaveCurrentCoefficients();
                    _selectedFunction = value;
                    OnPropertyChanged();
                    LoadFunctionData();
                }
            }
        }

        /// <summary>
        /// Коэффициент A
        /// </summary>
        /// 

        public double A 
        { 
            get => _a; 
            set 
            { 
                if (_a != value)
                {
                    _a = value;
                    UpdateCoefficients();
                    OnPropertyChanged();
                    
                }
            } 
        }

        /// <summary>
        /// Коэффициент B
        /// </summary>
        public double B
        {
            get => _b;
            set
            {
                if (_b != value)
                {
                    _b = value;
                    UpdateCoefficients();
                    OnPropertyChanged();
                    
                }
            }
        }
        /// <summary>
        /// Коэффициент C
        /// </summary>
        public double C
        {
            get => _c;
            set
            {
                if (_c != value)
                {
                    _c = value;
                    UpdateCoefficients();
                    OnPropertyChanged();
                    
                }
            }
        }

        /// <summary>
        /// Коллекция строк таблицы с входными данными и результатами
        /// </summary>
        public ObservableCollection<InputRow> InputRows { get; set; } = new ();
        #endregion

        #region Конструктор и инициализация

        /// <summary>
        /// Конструктор ViewModel.
        /// </summary>
        public MainViewModel()
        {
            _calculatorFactory = new FunctionCalculatorFactory();  
            _functionManager = new FunctionManager(_calculatorFactory);
            Functions = new ObservableCollection<FunctionType>(Enum.GetValues<FunctionType>());
            AddRowCommand = new RelayCommand(AddInputRow);
            SelectedFunction = Functions[0];
        }

        /// <summary>
        /// Сохраняет текущие коэффициенты для текущей функции.
        /// </summary>
        private void SaveCurrentCoefficients()
        {
            _functionManager.SetCoefficients(SelectedFunction, A, B, C);
            _functionManager.SetRows(SelectedFunction, InputRows.ToList());

        }

        /// <summary>
        /// Загружает коэффициенты и строки для выбранной функции.
        /// </summary>
        private void LoadFunctionData()
        {
            var coefficients = _functionManager.GetCoefficients(SelectedFunction);
            A = coefficients.a;
            B = coefficients.b;
            C = coefficients.c;

            var rows = _functionManager.GetRows(SelectedFunction);
            InputRows = new ObservableCollection<InputRow>(rows);
            OnPropertyChanged(nameof(InputRows));
            RecalculateResult();
        }

        /// <summary>
        /// Обновляет коэффициенты в FunctionManager и пересчитывает результаты.
        /// </summary>
        private void UpdateCoefficients()
        {
            _functionManager.SetCoefficients(SelectedFunction, A, B, C);
            RecalculateResult();
        }

        /// <summary>
        /// Пересчитывает все результаты f(x,y) для текущей функции.
        /// </summary>
        private void RecalculateResult()
        {
            _functionManager.SetCoefficients(SelectedFunction, A, B, C);
            _functionManager.Recalculate(SelectedFunction);
            foreach (var row in InputRows)
                OnPropertyChanged(nameof(row.Result));
        }

        /// <summary>
        /// Добавляет новую пустую строку в таблицу.
        /// </summary>
        private void AddInputRow()
        {
            var calculator = _calculatorFactory.Create(SelectedFunction, A, B, C);
            var newRow = new InputRow(calculator) { X = 0, Y = 0, Result = 0 };
            InputRows.Add(newRow);
            RecalculateResult();
        }
               
        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

    }
}
