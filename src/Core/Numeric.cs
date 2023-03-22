namespace TeXpressions.Core;

using TeXpressions.Core.Common;
using TeXpressions.Core.Formatting;
using TeXpressions.Core.Interfaces;

public static class Numeric
{
    #region Helpers
    public static BinaryTeXpression<double, double, double> Binary(
        TeXpression<double> left,
        TeXpression<double> right,
        Func<double, double, double> function,
        ILaTeXFormatter formatter) => new(left, right, function, formatter);

    public static UnaryTeXpression<double, double> Unary(TeXpression<double> inner, Func<double, double> function, ILaTeXFormatter formatter)
        => new(inner, function, formatter);

    public static ConstantTeXpression<double> Constant(double value, ILaTeXFormatter? formatter = null)
        => new(value, formatter ?? new ConstantLaTeXFormatter("0.###"));

    public static ParameterTeXpression<double> Parameter(string latexName, TeXpression<double>? inner = null, ILaTeXFormatter? formatter = null)
        => new(new(latexName, inner), formatter ?? new ParameterLaTeXFormatter());

    #endregion

    #region Maths

    public static BinaryTeXpression<double, double, double> Add(TeXpression<double> left, TeXpression<double> right, ILaTeXFormatter? formatter = null)
        => new(left, right, (l, r) => l + r, formatter ?? new CompositeLaTeXFormatter("{0} + {1}"));

    public static BinaryTeXpression<double, double, double> Divide(TeXpression<double> dividend, TeXpression<double> divisor, ILaTeXFormatter? formatter = null)
        => new(dividend, divisor, (l, r) => l / r, formatter ?? new DivideLaTeXFormatter());

    public static BinaryTeXpression<double, double, double> Exponent(TeXpression<double> @base, TeXpression<double> power, ILaTeXFormatter? formatter = null)
        => new(@base, power, (l, r) => Math.Pow(l, r), formatter ?? new CompositeLaTeXFormatter("{{{0}}}^{{{1}}}"));

    public static SetTeXpression<double, double> Max(TeXpression<double>[] inners, ILaTeXFormatter? formatter = null)
        => new(inners, (i) => i.Max(), formatter ?? new CompositeLaTeXFormatter("max({0})"));

    public static SetTeXpression<double, double> Min(TeXpression<double>[] inners, ILaTeXFormatter? formatter = null)
        => new(inners, (i) => i.Min(), formatter ?? new CompositeLaTeXFormatter("min({0})"));

    public static BinaryTeXpression<double, double, double> Multiply(TeXpression<double> left, TeXpression<double> right, ILaTeXFormatter? formatter = null)
        => new(left, right, (l, r) => l * r, formatter ?? new MultiplyLaTeXFormatter());

    public static UnaryTeXpression<double, double> Negate(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, (i) => -i, formatter ?? new CompositeLaTeXFormatter("{{-{0}}}"));

    public static UnaryTeXpression<double, double> SquareRoot(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, (i) => Math.Sqrt(i), formatter ?? new CompositeLaTeXFormatter(@"\sqrt{{{0}}}"));

    public static BinaryTeXpression<double, double, double> Subtract(TeXpression<double> left, TeXpression<double> right, ILaTeXFormatter? formatter = null)
        => new(left, right, (l, r) => l - r, formatter ?? new CompositeLaTeXFormatter("{0} - {1}"));

    #region Trig

    public static UnaryTeXpression<double, double> Cos(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Cos(i), formatter ?? new CompositeLaTeXFormatter(@"\cos{{{0}}}"));

    public static UnaryTeXpression<double, double> Sin(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Sin(i), formatter ?? new CompositeLaTeXFormatter(@"\sin{{{0}}}"));

    public static UnaryTeXpression<double, double> Tan(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Tan(i), formatter ?? new CompositeLaTeXFormatter(@"\tan{{{0}}}"));

    public static UnaryTeXpression<double, double> Sec(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => throw new NotImplementedException(), formatter ?? new CompositeLaTeXFormatter(@"\sec{{{0}}}"));

    public static UnaryTeXpression<double, double> Csc(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => throw new NotImplementedException(), formatter ?? new CompositeLaTeXFormatter(@"\csc{{{0}}}"));

    public static UnaryTeXpression<double, double> Cot(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => throw new NotImplementedException(), formatter ?? new CompositeLaTeXFormatter(@"\cot{{{0}}}"));

    public static UnaryTeXpression<double, double> ArcCos(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Acos(i), formatter ?? new CompositeLaTeXFormatter(@"\cos^{-1}{{{0}}}"));

    public static UnaryTeXpression<double, double> ArcSin(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Asin(i), formatter ?? new CompositeLaTeXFormatter(@"\sin^{-1}{{{0}}}"));

    public static UnaryTeXpression<double, double> ArcTan(TeXpression<double> inner, ILaTeXFormatter? formatter = null)
        => new(inner, i => Math.Atan(i), formatter ?? new CompositeLaTeXFormatter(@"\tan^{-1}{{{0}}}"));

    #endregion

    #endregion

    #region Common

    public static ParameterTeXpression<double> Pi(ILaTeXFormatter? formatter = null) => new(PiParameterValue, formatter ?? new ParameterLaTeXFormatter());

    private static readonly ParameterValue<double> PiParameterValue = new(@"\pi", new ConstantTeXpression<double>(Math.PI, new ConstantLaTeXFormatter("#.###")));

    #endregion
}
