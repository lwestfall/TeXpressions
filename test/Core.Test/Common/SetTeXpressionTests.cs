namespace Core.Test.Common;

using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Core.Interfaces;

public class SetTeXpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SetTeXpressionSimplifiesToConstantIfAllInnersAreConstant()
    {
        var values = new[] { 1, 2.2, 7.9, 0.125, -0.13, 999 };
        var constantTexprs = values.Select(v => Numeric.Constant(v)).ToArray();

        var texpr = Numeric.Min(
            constantTexprs
        );

        var result = texpr.Simplify();

        Assert.That(result, Is.InstanceOf<IConstantTeXpression>());
    }

    [Test]
    public void SetTeXpressionSimplifiesInnersIfNotAllAreConstant()
    {
        var values = new[] { 1, 2.2, 7.9, 0.125, -0.13, 999 };
        var constantTexprs = values.Select(v => Numeric.Constant(v)).Cast<TeXpression<double>>().ToList();
        constantTexprs.Add(
            Numeric.Add(
                Numeric.Constant(0.01),
                Numeric.Constant(0.02)
            )
        );

        var texpr = Numeric.Min(
            constantTexprs.ToArray()
        );

        var result = texpr.Simplify();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ISetTeXpression>());
            Assert.That(((ISetTeXpression)result).Inners, Is.All.InstanceOf<IConstantTeXpression>());
        });
    }
}
