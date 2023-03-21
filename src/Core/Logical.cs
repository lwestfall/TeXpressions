namespace TeXpressions.Core;

using TeXpressions.Core.Common;
using TeXpressions.Core.Formatting;
using TeXpressions.Core.Interfaces;

public static class Logical
{
    #region Helpers

    public static BinaryTeXpression<bool, bool, bool> Binary(
        TeXpression<bool> left,
        TeXpression<bool> right,
        Func<bool, bool, bool> function,
        ILaTeXFormatter formatter) => new(left, right, function, formatter);

    public static UnaryTeXpression<bool, bool> Unary(TeXpression<bool> inner, Func<bool, bool> function, ILaTeXFormatter formatter)
        => new(inner, function, formatter);

    public static ConstantTeXpression<bool> Constant(bool value, ILaTeXFormatter? formatter = null)
        => new(value, formatter ?? new ConstantLaTeXFormatter());

    public static ParameterTeXpression<bool> Parameter(string latexName, TeXpression<bool>? inner = null, ILaTeXFormatter? formatter = null)
        => new(new(latexName, inner), formatter ?? new ParameterLaTeXFormatter());

    public static BinaryTeXpression<double, double, bool> NumericComparison(
        TeXpression<double> left,
        TeXpression<double> right,
        Func<double, double, bool> function,
        ILaTeXFormatter formatter) => new(left, right, function, formatter);

    #endregion

    #region Numeric Comparison

    public static BinaryTeXpression<double, double, bool> LessThan(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l < r, formatter ?? new CompositeLaTeXFormatter("{0} < {r}"));

    public static BinaryTeXpression<double, double, bool> LessThanEqualTo(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l <= r, formatter ?? new CompositeLaTeXFormatter(@"{0} \leq {r}"));

    public static BinaryTeXpression<double, double, bool> GreaterThan(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l > r, formatter ?? new CompositeLaTeXFormatter("{0} > {r}"));

    public static BinaryTeXpression<double, double, bool> GreaterThanEqualTo(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l >= r, formatter ?? new CompositeLaTeXFormatter(@"{0} \geq {r}"));

    public static BinaryTeXpression<double, double, bool> EqualTo(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l == r, formatter ?? new CompositeLaTeXFormatter("{0} = {r}"));

    public static BinaryTeXpression<double, double, bool> NotEqualTo(
        TeXpression<double> left,
        TeXpression<double> right,
        ILaTeXFormatter? formatter = null) => NumericComparison(left, right, (l, r) => l != r, formatter ?? new CompositeLaTeXFormatter(@"{0} \neq {r}"));

    #endregion

    #region Boolean Algebra

    public static ConstantTeXpression<bool> True(ILaTeXFormatter? formatter = null)
        => new(true, formatter ?? new BooleanLiteralLaTeXFormatter());

    public static ConstantTeXpression<bool> False(ILaTeXFormatter? formatter = null)
        => new(false, formatter ?? new BooleanLiteralLaTeXFormatter());

    public static BinaryTeXpression<bool, bool, bool> And(
        TeXpression<bool> left,
        TeXpression<bool> right,
        ILaTeXFormatter? formatter = null) => Binary(left, right, (l, r) => l && r, formatter ?? new CompositeLaTeXFormatter(@"{0} \land {1}"));

    public static BinaryTeXpression<bool, bool, bool> Or(
        TeXpression<bool> left,
        TeXpression<bool> right,
        ILaTeXFormatter? formatter = null) => Binary(left, right, (l, r) => l || r, formatter ?? new CompositeLaTeXFormatter(@"{0} \or {1}"));

    public static BinaryTeXpression<bool, bool, bool> EqualTo(
        TeXpression<bool> left,
        TeXpression<bool> right,
        ILaTeXFormatter? formatter = null) => Binary(left, right, (l, r) => l == r, formatter ?? new CompositeLaTeXFormatter("{0} = {1}"));

    public static BinaryTeXpression<bool, bool, bool> NotEqualTo(
        TeXpression<bool> left,
        TeXpression<bool> right,
        ILaTeXFormatter? formatter = null) => Binary(left, right, (l, r) => l != r, formatter ?? new CompositeLaTeXFormatter(@"{0} \neq {1}"));

    public static UnaryTeXpression<bool, bool> Not(
        TeXpression<bool> inner,
        ILaTeXFormatter? formatter = null) => Unary(inner, i => !i, formatter ?? new CompositeLaTeXFormatter(@"\lnot{0}"));

    #endregion
}
