namespace TeXpressions.Test.Formatting;

using System.Globalization;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Core.Formatting;

public class LaTeXFormatterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1.23, "{0}", "1.23")]
    [TestCase(1.23, "", "")]
    [TestCase(1.23, "Hey{0}", "Hey1.23")]
    public void CompositeLaTeXFormatterFormatsCorrectlyForUnary(double value, string compositeFormat, string expectedOutput)
    {
        var expr = new UnaryTeXpression<double, double>(
            new ConstantTeXpression<double>(value, new ConstantLaTeXFormatter()),
            (v) => v,
            new CompositeLaTeXFormatter(compositeFormat)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expectedOutput));
    }

    [TestCase(1.5, 2.25, "{0}", "1.5")]
    [TestCase(2, 1, "{0} + {1}", "2 + 1")]
    [TestCase(3.3, 6.6, "Hey{0}{1}", "Hey3.36.6")]
    public void CompositeLaTeXFormatterFormatsCorrectlyForBinary(double leftVal, double rightVal, string compositeFormat, string expectedOutput)
    {
        var constFmtr = new ConstantLaTeXFormatter();

        var expr = new BinaryTeXpression<double, double, double>(
            new ConstantTeXpression<double>(leftVal, constFmtr),
            new ConstantTeXpression<double>(rightVal, constFmtr),
            (l, r) => 1,
            new CompositeLaTeXFormatter(compositeFormat)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expectedOutput));
    }

    [TestCase(new[] { 1.5, 2.25 }, "{0}", "1.5, 2.25")]
    [TestCase(new[] { 2.0, 1.0 }, "{0} + ", "2, 1 + ")]
    [TestCase(new[] { 3.3, 6.6 }, "Hey{0}", "Hey3.3, 6.6")]
    public void CompositeLaTeXFormatterFormatsCorrectlyForSet(double[] vals, string compositeFormat, string expectedOutput)
    {
        var constFmtr = new ConstantLaTeXFormatter();

        var expr = new SetTeXpression<double, double>(
            vals.Select(v => new ConstantTeXpression<double>(v, constFmtr)).ToArray(),
            v => 1,
            new CompositeLaTeXFormatter(compositeFormat)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void CompositeLaTeXFormatterThrowsNotImplementedExceptionForConstantTeXpression()
    {
        var expr = new ConstantTeXpression<double>(1.25, new CompositeLaTeXFormatter(""));

        Assert.Throws<NotImplementedException>(() => expr.ToLaTeX());
    }

    [TestCase(1.23, "", "en-US", "1.23")]
    [TestCase(1.23, "#", "en-US", "1")]
    [TestCase(1.23, "F4", "en-US", "1.2300")]
    [TestCase(1.23, "C", "en-US", "$1.23")]
    [TestCase(1.23, "C", "ja-JP", "￥1")]
    [TestCase(1.23, "e3", "en-US", "1.230e+000")]
    [TestCase(1.23, "E", "fr-FR", "1,230000E+000")]
    public void ConstantLaTeXFormatterFormatsCorrectlyForCulture(double value, string formatStr, string culture, string expectedOutput)
    {
        var expr = new ConstantTeXpression<double>(value, new ConstantLaTeXFormatter(formatStr))
        {
            FormatProvider = CultureInfo.CreateSpecificCulture(culture)
        };

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expectedOutput));
    }

    [TestCase(1, 2, DivideStyle.Slash, "{1} / {2}")]
    [TestCase(21, 7, DivideStyle.StandardFraction, "\\frac{21}{7}")]
    [TestCase(50, 123.23, DivideStyle.SlantedFraction, "\\sfrac{50}{123.23}")]
    public void DivideLaTeXFormatterFormatsCorrectly(double dividend, double divisor, DivideStyle style, string expected)
    {
        var expr = Numeric.Divide(
            Numeric.Constant(dividend),
            Numeric.Constant(divisor),
            new DivideLaTeXFormatter(style)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void DivideLaTeXFormatterThrowsNotImplementedExceptionForNewDivideStyle()
    {
        var style = (DivideStyle)999;

        var expr = Numeric.Divide(
            Numeric.Constant(0),
            Numeric.Constant(0),
            new DivideLaTeXFormatter(style)
        );

        Assert.Throws<NotImplementedException>(() => expr.ToLaTeX());
    }

    [Test]
    public void IncompatibleFormatterThrowsInvalidOperationException()
    {
        var expr = Numeric.Constant(1, new DivideLaTeXFormatter());

        Assert.Throws<InvalidOperationException>(() => expr.ToLaTeX());
    }
}
