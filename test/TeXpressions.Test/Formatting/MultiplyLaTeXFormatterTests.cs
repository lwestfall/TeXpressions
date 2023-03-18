namespace TeXpressions.Test.Formatting;
using TeXpressions.Core;
using TeXpressions.Core.Formatting;

public class MultiplyLaTeXFormatterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1.5, 2, MultiplyStyle.Times, false, "1.5 \\times 2")]
    [TestCase(2.58, 7.54, MultiplyStyle.Dot, false, "2.58 \\dot 7.54")]
    [TestCase(-3.14, 4.24, MultiplyStyle.ParenthesesBoth, false, "(-3.14) (4.24)")]
    [TestCase(426, 784, MultiplyStyle.ParenthesesLeftOnly, false, "(426) 784")]
    [TestCase(1.55, 457, MultiplyStyle.ParenthesesRightOnly, false, "1.55 (457)")]
    public void MultiplyLaTeXFormatterFormats(double val1, double val2, MultiplyStyle style, bool smartFormat, string expected)
    {
        var expr = Numeric.Multiply(
            Numeric.Constant(val1),
            Numeric.Constant(val2),
            new MultiplyLaTeXFormatter(style, smartFormat)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LeftAndRightConstantsSmartFormattingNotAdjacentStyle()
    {
        var expected = "0 \\times 0";
        var expr = Numeric.Multiply(
            Numeric.Constant(0),
            Numeric.Constant(0),
            new MultiplyLaTeXFormatter(MultiplyStyle.Times, true)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LeftOnlyConstantSmartFormattingAdjacentStyle()
    {
        var expected = "1.5 \\frac{1}{2}";
        var expr = Numeric.Multiply(
            Numeric.Constant(1.5),
            Numeric.Divide(
                Numeric.Constant(1),
                Numeric.Constant(2)
            ),
            new MultiplyLaTeXFormatter(MultiplyStyle.Times, true)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RightOnlyConstantSmartFormattingAdjacentStyle()
    {
        var expected = "\\frac{1}{2} 1.5";
        var expr = Numeric.Multiply(
            Numeric.Divide(
                Numeric.Constant(1),
                Numeric.Constant(2)
            ),
            Numeric.Constant(1.5),
            new MultiplyLaTeXFormatter(MultiplyStyle.Times, true)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NoConstantSmartFormattingNotAdjacentStyle()
    {
        var expected = "\\frac{1}{2} \\times \\frac{3}{4}";
        var expr = Numeric.Multiply(
            Numeric.Divide(
                Numeric.Constant(1),
                Numeric.Constant(2)
            ),
            Numeric.Divide(
                Numeric.Constant(3),
                Numeric.Constant(4)
            ),
            new MultiplyLaTeXFormatter(MultiplyStyle.Times, true)
        );

        var actual = expr.ToLaTeX();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplyLaTeXFormatterThrowsNotImplementedExceptionForNewMultiplyStyle()
    {
        var style = (MultiplyStyle)999;

        var expr = Numeric.Multiply(
            Numeric.Constant(0),
            Numeric.Constant(0),
            new MultiplyLaTeXFormatter(style)
        );

        Assert.Throws<NotImplementedException>(() => expr.ToLaTeX());
    }
}
