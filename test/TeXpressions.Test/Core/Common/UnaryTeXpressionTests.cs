namespace TeXpressions.Test.Core.Common;
using TeXpressions.Core;
using TeXpressions.Core.Interfaces;

public class UnaryTeXpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void UnaryTeXpressionEvaluatesFunction()
    {
        var num = 9;
        var expected = 3;

        var texpr = Numeric
            .SquareRoot(
                Numeric.Constant(num)
            );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void UnaryTeXpressionSimplifiesToConstantIfInnerIsConstant()
    {
        var texpr = Numeric
            .SquareRoot(
                Numeric.Constant(9)
            );

        var result = texpr.Simplify();

        Assert.That(result, Is.InstanceOf<IConstantTeXpression>());
    }

    [Test]
    public void UnaryTeXpressionSimplifiesInnerIfInnerIsNotConstant()
    {
        var texpr = Numeric
            .SquareRoot(
                Numeric.Add(
                    Numeric.Constant(3),
                    Numeric.Constant(3)
                )
            );

        var result = texpr.Simplify();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<IUnaryTeXpression>());
            Assert.That(((IUnaryTeXpression)result).Inner, Is.InstanceOf<IConstantTeXpression>());
        });
    }
}
