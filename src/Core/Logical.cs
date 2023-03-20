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
    #endregion
}
