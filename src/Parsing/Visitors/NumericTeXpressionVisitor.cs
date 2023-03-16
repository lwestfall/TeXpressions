namespace TeXpressions.Parsing.Visitors;

using Antlr4.Runtime.Misc;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Extensions;
using static TeXpressionMathParser;

public class NumericTeXpressionVisitor : TeXpressionMathBaseVisitor<TeXpression<double>?>
{
    public override TeXpression<double>? VisitInlineMath([NotNull] InlineMathContext context)
        => this.Visit(context.expr());

    // todo: ideas for cleaning up
    //      more extension methods (e.g. TryGetNumericTeXpression(this BinaryExprContext ctx, TeXpression<double> left, TeXpression<double> right))
    public override TeXpression<double>? VisitBinaryExpr([NotNull] BinaryExprContext context)
    {
        if (context.l == null || context.r == null)
        {
            // todo throw exception
            return null;
        }

        var left = this.Visit(context.l);
        if (left == null)
        {
            // todo throw exception
            return null;
        }

        var right = this.Visit(context.r);
        if (right == null)
        {
            // todo throw exception
            return null;
        }

        var cmdName = context.binaryCmdName();
        if (cmdName != null)
        {
            if (cmdName.divCmd() != null)
            {
                return Numeric.Divide(
                    left,
                    right
                );
            }

            // todo throw exception
            return null;
        }

        var binOp = context.binaryOp();

        if (binOp != null)
        {
            return binOp.GetBinaryTeXpression(left, right);
        }

        // todo throw exception
        return null;
    }

    public override TeXpression<double>? VisitConstantExpr([NotNull] ConstantExprContext context)
    {
        if (context.number() == null)
        {
            // todo throw exception
            return null;
        }

        var num = context.number().GetDouble();

        if (num == null)
        {
            // todo throw exception
            return null;
        }

        return Numeric.Constant((double)num);
    }
}
