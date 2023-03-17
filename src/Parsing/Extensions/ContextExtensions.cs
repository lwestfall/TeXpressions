namespace TeXpressions.Parsing.Extensions;

using Antlr4.Runtime;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using static TeXpressionMathParser;

public static class ContextExtensions
{
    public static double? GetDouble(this ParserRuleContext ctx)
    {
        if (!double.TryParse(ctx.GetText(), out var dbl))
        {
            return null;
        }

        return dbl;
    }

    public static BinaryTeXpression<double, double, double> GetBinaryTeXpression(this BinaryOpContext ctx, TeXpression<double> left, TeXpression<double> right)
    {
        Dictionary<Func<BinaryOpContext, ParserRuleContext>, Func<TeXpression<double>, TeXpression<double>, BinaryTeXpression<double, double, double>>> lookup = new()
        {
            {(ctx) => ctx.addOp(), (l,r) => Numeric.Add(l,r)},
            {(ctx) => ctx.subOp(), (l,r) => Numeric.Subtract(l,r)},
            {(ctx) => ctx.divOp(), (l,r) => Numeric.Divide(l,r)},
            {(ctx) => ctx.mulOp(), (l,r) => Numeric.Multiply(l,r)},
            {(ctx) => ctx.expOp(), (l,r) => Numeric.Exponent(l,r)}
        };

        return lookup.First(kvp => kvp.Key(ctx) != null).Value(left, right);
    }
}
