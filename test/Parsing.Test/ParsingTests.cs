namespace Parsing.Test;
using NUnit.Framework;
using TeXpressions.Core.Common;
using TeXpressions.Parsing;
using TeXpressions.Parsing.Visitors;

public class ParsingTests
{
    [SetUp]
    public void Setup()
    {

    }

    [TestCase("$1.23$", 1.23)]
    public void NumberExpressionParsesToDouble(string input, double expected)
    {
        var parser = ParseUtility.GetParserForInput(input);
        // var listener = new TeXpressionMathBaseListener();

        // var context = parser.inlineMath();
        // listener.EnterInlineMath(context);
        // listener.ExitInlineMath(context);
        var visitor = new NumericTeXpressionVisitor();
        var ctx = parser.inlineMath();
        var actual = visitor.Visit(ctx);

        Assert.That(actual, Is.Not.Null);

        var constExpr = (ConstantTeXpression<double>)actual!;

        var evaulatedActual = constExpr.Evaluate();

        Assert.That(evaulatedActual, Is.EqualTo(expected));
    }
}
