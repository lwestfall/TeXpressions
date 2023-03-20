namespace TeXpressions.Parsing.Extensions;

using TeXpressions.Core;
using TeXpressions.Core.Common;
using static TeXpressionParser;
using BinaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.TeXpression<double>, Core.Common.BinaryTeXpression<double, double, double>>;
using UnaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.UnaryTeXpression<double, double>>;

public static class ContextExtensions
{
    public static UnaryTeXpression<double, double> ToUnaryNumericTeXpression(this UnaryNumExprContext ctx, TeXpression<double> inner)
    {
        if (ctx.unaryNumOpPre() != null)
        {
            Dictionary<Func<UnaryNumOpPreContext, object>, UnaryNumericFactory> opLookup = new()
            {
                {ctx => ctx.negNumOp(), i => Numeric.Negate(i)}
            };

            return opLookup.First(kvp => kvp.Key(ctx.unaryNumOpPre()) != null).Value(inner);
        }

        Dictionary<Func<UnaryNumCmdNameContext, object>, UnaryNumericFactory> cmdLookup = new()
        {
            {ctx => ctx.GetText() == @"\sqrt", i => Numeric.SquareRoot(i)}
        };

        return cmdLookup.First(kvp => kvp.Key(ctx.unaryNumCmdName()) != null).Value(inner);
    }

    public static BinaryTeXpression<double, double, double> ToBinaryNumericTeXpression(
        this BinaryNumExprContext ctx,
        TeXpression<double> left,
        TeXpression<double> right)
    {
        if (ctx.binaryCmdName() != null)
        {
            Dictionary<Func<BinaryCmdNameContext, object>, BinaryNumericFactory> cmdLookup = new()
        {
            {(ctx) => ctx.divCmd(), (l,r) => Numeric.Divide(l,r)}
        };

            return cmdLookup.First(kvp => kvp.Key(ctx.binaryCmdName()) != null).Value(left, right);
        }

        Dictionary<Func<BinaryNumExprContext, object>, BinaryNumericFactory> opLookup = new()
        {
            {(ctx) => ctx.EXP_OP(), (l,r) => Numeric.Exponent(l,r)},
            {(ctx) => ctx.MUL_OP(), (l,r) => Numeric.Multiply(l,r)},
            {(ctx) => ctx.DIV_OP(), (l,r) => Numeric.Divide(l,r)},
            {(ctx) => ctx.ADD_OP(), (l,r) => Numeric.Add(l,r)},
            {(ctx) => ctx.SUB_OP(), (l,r) => Numeric.Subtract(l,r)}
        };

        return opLookup.First(kvp => kvp.Key(ctx) != null).Value(left, right);
    }
}
