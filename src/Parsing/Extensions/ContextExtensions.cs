namespace TeXpressions.Parsing.Extensions;

using Antlr4.Runtime.Tree;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using static TeXpressionParser;
using BinaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.TeXpression<double>, Core.Common.BinaryTeXpression<double, double, double>>;
using UnaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.UnaryTeXpression<double, double>>;

public static class ContextExtensions
{
    public static UnaryTeXpression<double, double> ToUnaryNumericTeXpression(this UnaryNumExprContext ctx, TeXpression<double> inner)
    {
        var opCtx = ctx.unaryNumOpLeft();

        if (opCtx?.negNumOp() != null)
        {
            return Numeric.Negate(inner);
        }

        Dictionary<Func<UnaryNumCmdLeftContext, object>, UnaryNumericFactory> cmdLookup = new()
        {
            {ctx => ctx.GetText() == @"\sqrt", i => Numeric.SquareRoot(i)}
        };

        return cmdLookup.First(kvp => kvp.Key(ctx.unaryNumCmdLeft()) != null).Value(inner);
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

    public static UnaryTeXpression<bool, bool> ToUnaryLogicTeXpression(this UnaryLogicExprContext ctx, TeXpression<bool> inner)
    {
        if (ctx.unaryLogicOpPre().negLogicalOp() != null)
        {
            return Logical.Not(inner);
        }

        throw new NotImplementedException();
    }

    public static BinaryTeXpression<bool, bool, bool> ToBinaryLogicTeXpression(
        this BinaryLogicExprContext ctx,
        TeXpression<bool> left,
        TeXpression<bool> right)
    {
        if (ctx.AND_OP() != null)
        {
            return Logical.And(left, right);
        }
        if (ctx.OR_OP() != null)
        {
            return Logical.Or(left, right);
        }

        if (EqOpIsEquals(ctx.EQ_OP()))
        {
            return Logical.EqualTo(left, right);
        }
        else
        {
            return Logical.NotEqualTo(left, right);
        }

        throw new NotImplementedException();
    }

    public static BinaryTeXpression<double, double, bool> ToNumericComparisonTeXpression(
        this NumericCompareExprContext ctx,
        TeXpression<double> left,
        TeXpression<double> right)
    {
        var eqOp = ctx.cmpOp().EQ_OP();

        if (eqOp != null)
        {
            return eqOp.GetText() switch
            {
                "=" or @"\leftrightarrow" or @"\Leftrightarrow" => Logical.EqualTo(left, right),
                "!=" or @"\neq" => Logical.NotEqualTo(left, right),
                _ => throw new NotImplementedException(),
            };
        }

        return ctx.cmpOp().GetText() switch
        {
            ">" => Logical.GreaterThan(left, right),
            @"\geq" or ">=" => Logical.GreaterThanEqualTo(left, right),
            "<" => Logical.LessThan(left, right),
            @"\leq" or "<=" => Logical.LessThanEqualTo(left, right),
            _ => throw new NotImplementedException(),
        };
    }

    private static bool EqOpIsEquals(ITerminalNode opNode)
    {
        // todo - rewrite this to make it 100% coverable
        return opNode.GetText() switch
        {
            "=" or @"\leftrightarrow" or @"\Leftrightarrow" => true,
            "!=" or @"\neq" => false,
            _ => throw new NotImplementedException(),
        };
    }
}
