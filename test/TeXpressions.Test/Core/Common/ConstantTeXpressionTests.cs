namespace TeXpressions.Test.Core.Common;

using TeXpressions.Core;
using TeXpressions.Test.Core.Mocks;

public class ConstantTeXpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SimplifyReplacesFormatter()
    {
        var oldFormatter = new MockLaTeXFormatter();
        var constantTexpr = Numeric.Constant(1, oldFormatter);

        var newFormatter = new MockLaTeXFormatter();

        constantTexpr.Simplify(newFormatter);

        Assert.That(constantTexpr.LaTeXFormatter, Is.EqualTo(newFormatter));
        Assert.That(constantTexpr.LaTeXFormatter, Is.Not.EqualTo(oldFormatter));
    }

    [Test]
    public void SimplifyReturnsSelf()
    {
        var constantTexpr = Numeric.Constant(1, new MockLaTeXFormatter());

        var result = constantTexpr.Simplify();

        Assert.That(result, Is.EqualTo(constantTexpr));
    }

    [TestCase(1)]
    [TestCase(2.25)]
    [TestCase(3.333333)]
    [TestCase(5000000.1)]
    public void EvaluateReturnsOriginal(double num)
    {
        var constantTexpr = Numeric.Constant(num);

        var result = constantTexpr.Evaluate();

        Assert.That(result, Is.EqualTo(num));
    }

    [Test]
    public void GetChildrenReturnsEmptyArray()
    {
        var constantTexpr = Numeric.Constant(1, new MockLaTeXFormatter());

        var result = constantTexpr.GetChildren();

        Assert.That(result, Is.Empty);
    }
}
