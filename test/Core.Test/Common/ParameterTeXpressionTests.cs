namespace Core.Test.Common;
using TeXpressions.Core;
using TeXpressions.Core.Common;

public class ParameterTeXpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EvaluationOfUnsetThrowsInvalidOperationException()
    {
        var paramTeXpr = Numeric.Parameter("a");

        Assert.Throws<InvalidOperationException>(() => paramTeXpr.Evaluate());
    }

    [Test]
    public void EvaluationOfSetParameterReturnsCorrectEvaluation()
    {
        var expected = 1.5;
        var paramTeXpr = Numeric.Parameter("a", Numeric.Constant(expected));

        // todo - add test cases for different types of expressions

        var result = paramTeXpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SimplifiesToConstantWhenSet()
    {
        var expected = 1.5;
        var paramTeXpr = Numeric.Parameter("a", Numeric.Constant(expected));

        // todo - add test cases for different types of expressions

        var result = paramTeXpr.Simplify();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(((ConstantTeXpression<double>)result).Value, Is.EqualTo(expected));
        });
    }
}
