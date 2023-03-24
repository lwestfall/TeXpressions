namespace TeXpressions.Parsing.Extensions;

using System.Text.RegularExpressions;
using Antlr4.Runtime.Tree;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using static TeXpressionParser;
using BinaryNumericFactory = Func<Core.Common.TeXpression<double>, Core.Common.TeXpression<double>, Core.Common.BinaryTeXpression<double, double, double>>;

public static class ContextExtensions
{
    public static UnaryTeXpression<double, double> ToUnaryNumericTeXpression(this UnaryNumExprContext ctx, TeXpression<double> inner)
    {
        var opText = ctx.unaryNumOpLeft().GetText();

        if (opText == @"\sqrt")
        {
            return Numeric.SquareRoot(inner);
        }

        if (opText == @"-")
        {
            return Numeric.Negate(inner);
        }

        var trigFunc = ctx.unaryNumOpLeft().trigFunc();

        if (trigFunc != null)
        {
            return GetTeXpressionFromTrigFunc(trigFunc, inner);
        }

        throw new NotImplementedException();
    }

    private static UnaryTeXpression<double, double> GetTeXpressionFromTrigFunc(TrigFuncContext ctx, TeXpression<double> inner)
    {
        var func = ctx.basicTrigFunc()?.GetText() ?? ctx.GetText();

        if (ctx.basicTrigFunc() != null)
        {
            var inverse = false;
            var sq = false;
            if (ctx.trigSuper() != null)
            {
                // not the best - strip nonnumeric characters (including -)
                // use result to determine modifier
                var num = Regex.Replace(ctx.trigSuper().GetText(), @"\D", string.Empty);
                inverse = num == "1";
                sq = num == "2";
            }

            if (func == @"\sin")
            {
                if (inverse)
                {
                    return Numeric.ArcSin(inner);
                }

                if (sq)
                {
                    return Numeric.SinSquared(inner);
                }

                return Numeric.Sin(inner);
            }

            if (func == @"\cos")
            {
                if (inverse)
                {
                    return Numeric.ArcCos(inner);
                }

                if (sq)
                {
                    return Numeric.CosSquared(inner);
                }

                return Numeric.Cos(inner);
            }

            if (func == @"\tan")
            {
                if (inverse)
                {
                    return Numeric.ArcTan(inner);
                }

                if (sq)
                {
                    return Numeric.TanSquared(inner);
                }

                return Numeric.Tan(inner);
            }

            if (func == @"\cot")
            {
                if (inverse || sq)
                {
                    throw new NotImplementedException();
                }

                return Numeric.Cot(inner);
            }

            if (func == @"\sec")
            {
                if (inverse || sq)
                {
                    throw new NotImplementedException();
                }

                return Numeric.Sec(inner);
            }

            if (func == @"\csc")
            {
                if (inverse || sq)
                {
                    throw new NotImplementedException();
                }

                return Numeric.Csc(inner);
            }
        }

        if (func == @"\arcsin")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\arccos")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\arctan")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\arccot")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\sinh")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\cosh")
        {
            return Numeric.ArcSin(inner);
        }
        if (func == @"\tanh")
        {
            return Numeric.ArcSin(inner);
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
