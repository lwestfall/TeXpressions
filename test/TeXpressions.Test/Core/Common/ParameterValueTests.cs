namespace Core.Test.Common;

using TeXpressions.Core.Common;
using TeXpressions.Core.Formatting;
using TeXpressions.Test.Core.Mocks;

public class ParameterValueTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullFormatterInGetNewTeXpressionUsesParameterFormatter()
    {
        var paramValue = new ParameterValue<double>("A");

        var paramTeXpr = paramValue.GetNewTeXpression();

        Assert.That(paramTeXpr.LaTeXFormatter, Is.InstanceOf<ParameterLaTeXFormatter>());
    }

    [Test]
    public void CustomFormatterInGetNewTeXpressionUsesThatFormatter()
    {
        var paramValue = new ParameterValue<double>("A");

        var paramTeXpr = paramValue.GetNewTeXpression(new MockLaTeXFormatter());

        Assert.That(paramTeXpr.LaTeXFormatter, Is.InstanceOf<MockLaTeXFormatter>());
    }

    [Test]
    public void GetNewTeXpressionGeneratesDifferentTeXpressionsUsingSameParameterValueReference()
    {
        var paramValue = new ParameterValue<double>("A");

        var paramTeXpr1 = paramValue.GetNewTeXpression();
        var paramTeXpr2 = paramValue.GetNewTeXpression();

        Assert.Multiple(() =>
        {
            Assert.That(paramTeXpr2, Is.Not.EqualTo(paramTeXpr1));
            Assert.That(paramValue, Is.EqualTo(paramTeXpr1.ParameterValue));
            Assert.That(paramValue, Is.EqualTo(paramTeXpr2.ParameterValue));
        });
    }
}
