namespace Core.Test.Common;

using Core.Test.Mocks;
using TeXpressions.Core;

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
}
