namespace TeXpressions.Parsing.Extensions;

using System.Globalization;
using Antlr4.Runtime.Tree;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using static TeXpressionParser;
using BinaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.TeXpression<double>, Core.Common.BinaryTeXpression<double, double, double>>;

public static class ContextExtensions
{
    public static TeXpression ToNumericTeXpression(this VarContext ctx, TeXpression<double>? valueExpr = null)
    {
        var varLatex = ctx.GetText();

        if (valueExpr == null && varLatex == "e")
        {
            return Numeric.EulersNumber();
        }

        return Numeric.Parameter(varLatex, valueExpr);
    }

    public static UnaryTeXpression<double, double> ToUnaryNumericTeXpression(this UnaryNumExprContext ctx, TeXpression<double> inner)
    {
        var logFunc = ctx.unaryNumOpLeft()?.logFunc();
        if (logFunc != null)
        {
            if (logFunc.logBaseFunc() != null)
            {
                var baseStr = string.Concat(logFunc.logBaseFunc()._base.Select(t => t.Text));
                var @base = double.Parse(baseStr, CultureInfo.CurrentCulture);

                return Numeric.LogBase(inner, @base);
            }

            return logFunc.logType.Text switch
            {
                @"\log" => Numeric.Log10(inner),
                @"\ln" => Numeric.Ln(inner),
                _ => throw new NotImplementedException(),
            };
        }

        var opText = ctx.unaryNumOpLeft().GetText();

        if (opText == @"\sqrt")
        {
            return Numeric.SquareRoot(inner);
        }

        if (opText == @"-")
        {
            return Numeric.Negate(inner);
        }

        throw new NotImplementedException();
    }

    public static UnaryTeXpression<double, double> GetTeXpressionFromTrigFuncExpr(this TrigFuncExprContext ctx, TeXpression<double> innerArg, TeXpression<double>? exp)
    {
        if (exp != null)
        {
            var expVal = exp?.Evaluate();

            if (expVal is not null and not (-1 or 2))
            {
                throw new InvalidOperationException($"BaseTrigFunc superscript evaluated to {expVal} must evaluate only to -1 or +2.");
            }

            var inverse = expVal == -1;
            var sq = expVal == 2;

            return ctx.baseTrigFunc().GetTeXpressionFromBaseTrigFunc(innerArg, inverse, sq);
        }

        return ctx.trigFunc().GetTeXpressionFromTrigFunc(innerArg);

    }

    private static UnaryTeXpression<double, double> GetTeXpressionFromBaseTrigFunc(this BaseTrigFuncContext ctx, TeXpression<double> innerArg, bool inverse, bool squared)
    {
        var func = ctx.GetText();

        if (func == @"\sin")
        {
            if (inverse)
            {
                return Numeric.ArcSin(innerArg);
            }

            if (squared)
            {
                return Numeric.SinSquared(innerArg);
            }

            return Numeric.Sin(innerArg);
        }

        if (func == @"\cos")
        {
            if (inverse)
            {
                return Numeric.ArcCos(innerArg);
            }

            if (squared)
            {
                return Numeric.CosSquared(innerArg);
            }

            return Numeric.Cos(innerArg);
        }

        if (func == @"\tan")
        {
            if (inverse)
            {
                return Numeric.ArcTan(innerArg);
            }

            if (squared)
            {
                return Numeric.TanSquared(innerArg);
            }

            return Numeric.Tan(innerArg);
        }

        throw new NotImplementedException();
    }

    private static UnaryTeXpression<double, double> GetTeXpressionFromTrigFunc(this TrigFuncContext ctx, TeXpression<double> innerArg)
    {
        if (ctx.baseTrigFunc() != null)
        {
            return ctx.baseTrigFunc().GetTeXpressionFromBaseTrigFunc(innerArg, false, false);
        }

        var func = ctx.GetText();

        if (func == @"\cot")
        {
            return Numeric.Cot(innerArg);
        }

        if (func == @"\sec")
        {
            return Numeric.Sec(innerArg);
        }

        if (func == @"\csc")
        {
            return Numeric.Csc(innerArg);
        }

        if (func == @"\arcsin")
        {
            return Numeric.ArcSin(innerArg);
        }
        if (func == @"\arccos")
        {
            return Numeric.ArcCos(innerArg);
        }
        if (func == @"\arctan")
        {
            return Numeric.ArcTan(innerArg);
        }
        if (func == @"\sinh")
        {
            return Numeric.SinH(innerArg);
        }
        if (func == @"\cosh")
        {
            return Numeric.CosH(innerArg);
        }
        if (func == @"\tanh")
        {
            return Numeric.TanH(innerArg);
        }

        throw new NotImplementedException();
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
