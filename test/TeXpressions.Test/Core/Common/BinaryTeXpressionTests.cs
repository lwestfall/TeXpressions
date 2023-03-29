namespace TeXpressions.Test.Core.Common;

using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Core.Interfaces;

public class BinaryTeXpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BinaryTeXpressionEvaluatesFunction()
    {
        var num1 = 5.5;
        var num2 = 2531.25;
        var expected = num1 + num2;

        var texpr = Numeric
            .Add(
                Numeric.Constant(num1),
                Numeric.Constant(num2)
            );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BinaryTeXpressionSimplifiesToConstantIfLeftAndRightAreConstant()
    {
        var texpr = Numeric
            .Add(
                Numeric.Constant(5.5),
                Numeric.Constant(2531.25)
            );

        var result = texpr.Simplify();

        Assert.That(result, Is.InstanceOf<ConstantTeXpression<double>>());
    }

    [Test]
    public void BinaryTeXpressionSimplifiesLeftBinaryOnce()
    {
        var texpr = Numeric
            .Add(
                Numeric.Add(
                    Numeric.Constant(1234),
                    Numeric.Constant(5678)
                ),
                Numeric.Constant(2531.25)
            );

        var result = texpr.Simplify();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<BinaryTeXpression<double, double, double>>());
            Assert.That(result, Is.InstanceOf<IBinaryTeXpression>());
            Assert.That(((IBinaryTeXpression)result).Left, Is.InstanceOf<IConstantTeXpression>());
            Assert.That(((IBinaryTeXpression)result).Right, Is.InstanceOf<IConstantTeXpression>());
        });
    }
}
