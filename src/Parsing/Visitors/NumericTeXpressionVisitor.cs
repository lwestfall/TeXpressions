namespace TeXpressions.Parsing.Visitors;

using Antlr4.Runtime.Misc;
using TeXpressions.Core;
using TeXpressions.Core.Interfaces;
using static TeXpressionMathParser;

public class NumericTeXpressionVisitor : TeXpressionMathBaseVisitor<ITeXpression?>
{
    public override ITeXpression? VisitBinaryExpr([NotNull] BinaryExprContext context)
    {
        if (context.binaryCmd() != null)
        {
            Console.WriteLine("Binary Command");
        }
        else if (context.binaryOp() != null)
        {
            Console.WriteLine("Binary Operator");
        }

        return null;
    }

    public override ITeXpression? VisitConstantExpr([NotNull] ConstantExprContext context)
    {
        if (context.number() != null)
        {
            var numStr = context.number().GetText();

            if (double.TryParse(numStr, out var num))
            {
                return Numeric.Constant(num);
            }
        }

        return null;
    }
}
