using FunctionCalculator.Models;
using FunctionCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalculator.Services.Interfaces
{
    interface IFunctionCalculatorFactory
    {
        IFunctionCalculator Create(FunctionType type, double a, double b, double c);
    }
}
