using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FunctionCalculator.Helpers
{
    /// <summary>
    /// Класс для валидации входных значений.
    /// </summary>
    public static class InputValidator
    {
        public static readonly DependencyProperty AllowOnlyNumbersProperty =
            DependencyProperty.RegisterAttached(
                "AllowOnlyNumbers",
                typeof(bool),
                typeof(InputValidator),
                new UIPropertyMetadata(false, OnAllowOnlyNumbersChanged));

        public static bool GetAllowOnlyNumbers(DependencyObject obj)
        {
            return (bool)obj.GetValue(AllowOnlyNumbersProperty);
        }

        public static void SetAllowOnlyNumbers(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowOnlyNumbersProperty, value);
        }

        private static void OnAllowOnlyNumbersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += TextBox_PreviewTextInput;
                    DataObject.AddPastingHandler(textBox, OnPaste);
                }
                else
                {
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                    DataObject.RemovePastingHandler(textBox, OnPaste);
                }
            }
        }

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }
    }
}
