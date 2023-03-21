namespace TeXpressions.Test.Parsing;
using NUnit.Framework;
using TeXpressions.Core.Common;
using TeXpressions.Parsing;

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
    [TestCase("$(25.25) * 4$", 101, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$49 ÷ 7$", 7, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase(@"$\sfrac{7.5}{2}$", 3.75, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase(@"$\dfrac{1}{2}$", 0.5, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase(@"$\tfrac{2}{0.5}$", 4, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase(@"$\frac{6}{2}$", 3, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$10 / 10$", 1, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$A_b = 1.5$", 1.5, typeof(ParameterTeXpression<double>))]
    [TestCase("$A = 1/2$", 0.5, typeof(ParameterTeXpression<double>))]
    [TestCase(@"$\alpha=1*5$", 5, typeof(ParameterTeXpression<double>))]
    [TestCase("$r=-5$", -5, typeof(ParameterTeXpression<double>))]
    [TestCase(@"$\sqrt{9}$", 3, typeof(UnaryTeXpression<double, double>))]
    [TestCase(@"$1 + 2 \times 5$", 11, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase(@"$(1 + 2) \times 5$", 15, typeof(BinaryTeXpression<double, double, double>))]
    [TestCase("$(1)$", 1, typeof(ConstantTeXpression<double>))]
    public void NumericExpressionParsesAndEvaluates(string input, double expectedEval, Type expectedType)
    {
        var expr = ParseUtility.ParseInlineExpression<TeXpression<double>>(input);
        var actualEval = expr.Evaluate();

        Assert.Multiple(() =>
        {
            Assert.That(actualEval, Is.EqualTo(expectedEval));
            Assert.That(expr, Is.InstanceOf(expectedType));
        });
    }

    [TestCase(@"$\beta_{min}=8.75\times A$", typeof(ParameterTeXpression<double>))]
    public void NumericExpressionParsesNoEvaluate(string input, Type expectedType)
    {
        var expr = ParseUtility.ParseInlineExpression<TeXpression<double>>(input);

        Assert.That(expr, Is.InstanceOf(expectedType));
    }

    [TestCase("$2 > 1$", true, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 >= 1$", true, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 >= 2$", true, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 < 1$", false, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 <= 1$", false, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 <= 2$", true, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 != 2$", false, typeof(BinaryTeXpression<double, double, bool>))]
    [TestCase("$2 != 1$", true, typeof(BinaryTeXpression<double, double, bool>))]
    // [TestCase("$2 = 1$", false, typeof(BinaryTeXpression<double, double, bool>))] // todo: these tests are breaking
    // [TestCase("$2 = 2$", true, typeof(BinaryTeXpression<double, double, bool>))] // todo: these tests are breaking
    [TestCase(@"$\top$", true, typeof(ConstantTeXpression<bool>))]
    [TestCase(@"$\neg\top$", false, typeof(UnaryTeXpression<bool, bool>))]
    [TestCase(@"$\neg\bot$", true, typeof(UnaryTeXpression<bool, bool>))]
    [TestCase(@"$\top \land \bot$", false, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\top \lor \bot$", true, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\top \lor 2 > 1$", true, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\top \land 2 > 1$", true, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\top \land 2 <= 1$", false, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\neg(2 > 1 \wedge 4 < 3) \leftrightarrow (\neg(2 > 1) \vee \lsim(4 < 3))$", true, typeof(BinaryTeXpression<bool, bool, bool>))]
    [TestCase(@"$\neg(2 > 1 \wedge 4 < 3) \neq \top$", false, typeof(BinaryTeXpression<bool, bool, bool>))]
    public void LogicalExpressionParsesAndEvaluates(string input, bool expectedEval, Type expectedType)
    {
        var expr = ParseUtility.ParseInlineExpression<TeXpression<bool>>(input);
        var actualEval = expr.Evaluate();

        Assert.Multiple(() =>
        {
            Assert.That(actualEval, Is.EqualTo(expectedEval));
            Assert.That(expr, Is.InstanceOf(expectedType));
        });
    }

    [TestCase(@"$\beta=A\landB\lor\top$", typeof(ParameterTeXpression<bool>))]
    [TestCase(@"$\beta=A>B$", typeof(ParameterTeXpression<bool>))]
    [TestCase(@"$\beta=A\leftrightarrowB$", typeof(ParameterTeXpression<bool>))]
    public void LogicalExpressionParsesNoEvaluate(string input, Type expectedType)
    {
        var expr = ParseUtility.ParseInlineExpression<TeXpression<bool>>(input);

        Assert.That(expr, Is.InstanceOf(expectedType));
    }
}
