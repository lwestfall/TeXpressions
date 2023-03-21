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

    public override TeXpression VisitGroupedNumExpr([NotNull] GroupedNumExprContext context)
        => this.Visit(context.groupedNum().numericExpr());

    public override TeXpression VisitGroupedLogicExpr([NotNull] GroupedLogicExprContext context)
        => this.Visit(context.groupedLogic().logicExpr());

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

    public override TeXpression VisitConstNumExpr([NotNull] ConstNumExprContext context)
    {
        var num = double.Parse(context.NUMBER().GetText(), CultureInfo.InvariantCulture);
        return Numeric.Constant(num);
    }

    public override TeXpression VisitParamNumExpr([NotNull] ParamNumExprContext context)
        => Numeric.Parameter(context.GetText());

    public override TeXpression VisitUnaryLogicExpr([NotNull] UnaryLogicExprContext context)
    {
        var inner = (TeXpression<bool>)this.Visit(context.logicExpr());
        return context.ToUnaryLogicTeXpression(inner);
    }

    public override TeXpression VisitBinaryLogicExpr([NotNull] BinaryLogicExprContext context)
    {
        var left = (TeXpression<bool>)this.Visit(context.logicExpr()[0]);
        var right = (TeXpression<bool>)this.Visit(context.logicExpr()[1]);

        return context.ToBinaryLogicTeXpression(left, right);
    }

    public override TeXpression VisitNumericCompareExpr([NotNull] NumericCompareExprContext context)
    {
        var left = (TeXpression<double>)this.Visit(context.numericExpr()[0]);
        var right = (TeXpression<double>)this.Visit(context.numericExpr()[1]);

        return context.ToNumericComparisonTeXpression(left, right);
    }

    public override TeXpression VisitConstLogicExpr([NotNull] ConstLogicExprContext context)
    {
        return context.LOGIC_CONST().GetText() switch
        {
            @"\top" => Logical.True(),
            @"\bot" => Logical.False(),
            _ => throw new NotImplementedException(),
        };
    }

    public override TeXpression VisitParamLogicExpr([NotNull] ParamLogicExprContext context)
        => Logical.Parameter(context.GetText());
}
