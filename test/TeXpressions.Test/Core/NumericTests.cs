namespace TeXpressions.Test.Core;

using TeXpressions.Core;
using TeXpressions.Core.Interfaces;
using TeXpressions.Test.Core.Mocks;

public class NumericTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BinaryProducesBinaryTeXpression()
    {
        var binary = Numeric.Binary(
            Numeric.Constant(1),
            Numeric.Constant(2),
            (l, r) => l % r,
            new MockLaTeXFormatter()
        );

        Assert.That(binary, Is.InstanceOf<IBinaryTeXpression>());
    }

    [Test]
    public void UnaryProducesUnaryTeXpression()
    {
        var unary = Numeric.Unary(
            Numeric.Constant(1),
            (i) => i,
            new MockLaTeXFormatter()
        );

        Assert.That(unary, Is.InstanceOf<IUnaryTeXpression>());
    }

    [TestCase(1, 2)]
    [TestCase(6.25, 2.5)]
    [TestCase(12, 849)]
    public void AddGivesCorrectEvaluation(double a, double b)
    {
        var expected = a + b;

        var texpr = Numeric.Add(
            Numeric.Constant(a),
            Numeric.Constant(b)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2)]
    [TestCase(6.25, 2.5)]
    [TestCase(12, 849)]
    public void DivideGivesCorrectEvaluation(double a, double b)
    {
        var expected = a / b;

        var texpr = Numeric.Divide(
            Numeric.Constant(a),
            Numeric.Constant(b)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2)]
    [TestCase(6.25, 2.5)]
    public void ExponentGivesCorrectEvaluation(double a, double b)
    {
        var expected = Math.Pow(a, b);

        var texpr = Numeric.Exponent(
            Numeric.Constant(a),
            Numeric.Constant(b)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MinGivesCorrectEvaluation()
    {
        var values = new[] { 1, 2.2, 7.9, 0.125, -0.13, 999 };
        var expected = values.Min();

        var constantTexprs = values.Select(v => Numeric.Constant(v)).ToArray();

        var texpr = Numeric.Min(
            constantTexprs
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MaxGivesCorrectEvaluation()
    {
        var values = new[] { 1, 2.2, 7.9, 0.125, -0.13, 999 };
        var expected = values.Max();

        var constantTexprs = values.Select(v => Numeric.Constant(v)).ToArray();

        var texpr = Numeric.Max(
            constantTexprs
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2)]
    [TestCase(6.25, 2.5)]
    public void MultiplyGivesCorrectEvaluation(double a, double b)
    {
        var expected = a * b;

        var texpr = Numeric.Multiply(
            Numeric.Constant(a),
            Numeric.Constant(b)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1)]
    [TestCase(6.25)]
    public void NegateGivesCorrectEvaluation(double a)
    {
        var expected = 0 - a;

        var texpr = Numeric.Negate(
            Numeric.Constant(a)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1)]
    [TestCase(6.25)]
    public void SquareRootGivesCorrectEvaluation(double a)
    {
        var expected = Math.Sqrt(a);

        var texpr = Numeric.SquareRoot(
            Numeric.Constant(a)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(1, 2)]
    [TestCase(6.25, 2.5)]
    public void SubtractGivesCorrectEvaluation(double a, double b)
    {
        var expected = a - b;

        var texpr = Numeric.Subtract(
            Numeric.Constant(a),
            Numeric.Constant(b)
        );

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase]
    public void PiEvaluatesToPi()
    {
        var expected = Math.PI;

        var texpr = Numeric.Pi();

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase]
    public void Log2GivesCorrectEvaluation()
    {
        var expected = 8;

        var texpr = Numeric.Log2(Numeric.Constant(256));

        var result = texpr.Evaluate();

        Assert.That(result, Is.EqualTo(expected));
    }
}
