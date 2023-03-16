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

    [TestCase("$1.23$", 1.23, typeof(ConstantTeXpression<double>))]
    [TestCase("$1 + 2$", 3, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$2^3$", 8, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$15.5 - 2.25$", 13.25, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$25.25 * 4$", 101, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$49 ÷ 7$", 7, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$\\sfrac{7.5}{2}$", 3.75, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$\\dfrac{1}{2}$", 0.5, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$\\tfrac{2}{0.5}$", 4, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$\\frac{6}{2}$", 3, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$10 / 10$", 1, typeof(BinaryTeXpression<double, double, double>))]
    public void NumericExpressionParses(string input, double expectedEval, Type expectedType)
    {
        var parser = ParseUtility.GetParserForInput(input);

        var visitor = new NumericTeXpressionVisitor();
        var ctx = parser.inlineMath();
        var expr = visitor.Visit(ctx);

        Assert.That(expr, Is.Not.Null);

        var actualEval = expr!.Evaluate();
        Assert.Multiple(() =>
        {
            Assert.That(actualEval, Is.EqualTo(expectedEval));
            Assert.That(expr, Is.InstanceOf(expectedType));
        });
    }
}
