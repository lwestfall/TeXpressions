namespace TeXpressions.Parsing.Visitors;

using System.Globalization;
using Antlr4.Runtime.Misc;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Extensions;
using static TeXpressionMathParser;

public class NumericTeXpressionVisitor : TeXpressionMathBaseVisitor<TeXpression<double>>
{
    public override TeXpression<double> VisitInlineMath([NotNull] InlineMathContext context)
        => this.Visit(context.expr());

    public override TeXpression<double> VisitBinaryExpr([NotNull] BinaryExprContext context)
    {
        var left = this.Visit(context.l);
        var right = this.Visit(context.r);

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
        }

        var binOp = context.binaryOp();
        return binOp.GetBinaryTeXpression(left, right);
    }

    public override TeXpression<double> VisitConstantExpr([NotNull] ConstantExprContext context)
    {
        var num = double.Parse(context.number().GetText(), CultureInfo.InvariantCulture);
        return Numeric.Constant(num);
    }
}
