namespace TeXpressions.Parsing.Visitors;

using System.Globalization;
using Antlr4.Runtime.Misc;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Extensions;
using static TeXpressionParser;

public class TeXpressionVisitor : TeXpressionBaseVisitor<TeXpression>
{
    public override TeXpression VisitInline([NotNull] InlineContext context)
        => this.Visit(context.topExpr());

    public override TeXpression VisitTopExpr([NotNull] TopExprContext context)
    {
        var texpr = this.Visit(context.expr());

        if (context.var() != null)
        {
            var varLatex = context.var().GetText();

            if (texpr is TeXpression<double> numTexpr)
            {
                return Numeric.Parameter(varLatex, numTexpr);
            }
            else if (texpr is TeXpression<bool> boolTexpr)
            {
                return Logical.Parameter(varLatex, boolTexpr);
            }
        }

        return texpr;
    }

    public override TeXpression VisitGroupNumExpr([NotNull] GroupNumExprContext context) => this.Visit(context.numericExpr());

    public override TeXpression VisitUnaryNumExpr([NotNull] UnaryNumExprContext context)
    {
        var inner = (TeXpression<double>)this.Visit(context.numericExpr());
        return context.ToUnaryNumericTeXpression(inner);
    }

    public override TeXpression VisitBinaryNumExpr([NotNull] BinaryNumExprContext context)
    {
        var left = (TeXpression<double>)this.Visit(context.numericExpr()[0]);
        var right = (TeXpression<double>)this.Visit(context.numericExpr()[1]);

        return context.ToBinaryNumericTeXpression(left, right);
    }

    public override TeXpression VisitConstantExpr([NotNull] ConstantExprContext context)
    {
        var num = double.Parse(context.NUMBER().GetText(), CultureInfo.InvariantCulture);
        return Numeric.Constant(num);
    }

    public override TeXpression VisitParamNumExpr([NotNull] ParamNumExprContext context) => Numeric.Parameter(context.GetText());
}
