using FunctionCalculator.Models.Calculators;
using Xunit;

namespace FunctionCalculator.Tests;

public class FunctionCalculatorsTests
{
    [Theory]
    [InlineData(2, 3, 4, 5, 6, 17)]
    [InlineData(0, 0, 0, 10, 20, 0)]
    [InlineData(-1, -2, -3, 1, 1, -6)]
    public void LinearFunctionCalculator_Calculate_ReturnsExpectedValue(double a, double b, double c, double x, double y, double expected)
    {
        var calc = new LinearFunctionCalculator(a, b, c);
        var result = calc.Calculate(x, y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 3, 13)]
    [InlineData(0, 0, 0, 5, 5, 0)]
    [InlineData(-1, -2, -3, 3, 2, -16)]
    public void QuadraticFunctionCalculator_Calculate_ReturnsExpectedValue(double a, double b, double c, double x, double y, double expected)
    {
        var calc = new QuadraticFunctionCalculator(a, b, c);
        var result = calc.Calculate(x, y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 2, 19)]  
    [InlineData(0, 0, 0, 3, 3, 0)]
    [InlineData(-1, -2, -3, 1, 1, -6)]
    public void CubicFunctionCalculator_Calculate_ReturnsExpectedValue(double a, double b, double c, double x, double y, double expected)
    {
        var calc = new CubicFunctionCalculator(a, b, c);
        var result = calc.Calculate(x, y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 2, 35)] 
    [InlineData(0, 0, 0, 1, 1, 0)]
    [InlineData(-1, -2, -3, 2, 2, -35)]
    public void Degree4FunctionCalculator_Calculate_ReturnsExpectedValue(double a, double b, double c, double x, double y, double expected)
    {
        var calc = new Degree4FunctionCalculator(a, b, c);
        var result = calc.Calculate(x, y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 2, 2, 67)]
    [InlineData(0, 0, 0, 1, 1, 0)]
    [InlineData(-1, -2, -3, 2, 2, -67)]
    public void Degree5FunctionCalculator_Calculate_ReturnsExpectedValue(double a, double b, double c, double x, double y, double expected)
    {
        var calc = new Degree5FunctionCalculator(a, b, c);
        var result = calc.Calculate(x, y);
        Assert.Equal(expected, result);
    }
}