namespace Core.Test.Common;

using System.Globalization;
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

    [TestCase(1, null, "1")]
    [TestCase(2.25, "", "2.25")]
    [TestCase(2.25, "#.#", "2.3")]
    [TestCase(2.25, "#.###", "2.25")]
    [TestCase(2.25, "F3", "2.250")]
    public void ToStringFormats(double num, string? fmt, string expected)
    {
        var constantTexpr = Numeric.Constant(num);

        var result = constantTexpr.ToString(fmt, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expected));
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
}
