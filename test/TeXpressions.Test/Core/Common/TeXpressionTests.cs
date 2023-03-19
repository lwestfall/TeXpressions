namespace TeXpressions.Test.Core.Common;
using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Core.Interfaces;

public class TeXpressionTests
{
    private readonly ITeXpression allTypesRoot = Numeric.Divide(
        Numeric.Multiply(       // 0
            Numeric.Max(        // 1
                new TeXpression<double>[] {
                    Numeric.Constant(5),        // 2
                    Numeric.Multiply(           // 3
                        Numeric.Negate(         // 4
                            Numeric.Parameter(  // 5
                                "x",
                                Numeric.Add(        // ParameterValue doesn't currently count in expression tree by design (but should it?)
                                    Numeric.Constant(1),
                                    Numeric.Constant(3.5)
                                )
                            )
                        ),
                        Numeric.Subtract(       // 6
                            Numeric.Constant(5),// 7
                            Numeric.Constant(3) // 8
                        )
                    )
                }
            ),
            Numeric.Constant(7) // 9
        ),
        Numeric.Constant(2)     // 10
    );

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void GetDescendantsGetsAllDescendants()
    {
        // var root = Numeric.Divide(
        //     Numeric.Multiply(       // 0
        //         Numeric.Max(        // 1
        //             new TeXpression<double>[] {
        //                 Numeric.Constant(5),        // 2
        //                 Numeric.Multiply(           // 3
        //                     Numeric.Negate(         // 4
        //                         Numeric.Parameter(  // 5
        //                             "x",
        //                             Numeric.Add(        // ParameterValue doesn't currently count in expression tree by design (but should it?)
        //                                 Numeric.Constant(1),
        //                                 Numeric.Constant(3.5)
        //                             )
        //                         )
        //                     ),
        //                     Numeric.Subtract(       // 6
        //                         Numeric.Constant(5),// 7
        //                         Numeric.Constant(3) // 8
        //                     )
        //                 )
        //             }
        //         ),
        //         Numeric.Constant(7) // 9
        //     ),
        //     Numeric.Constant(2)     // 10
        // );

        // formats to \frac{max(5, {-x} \times 5 - 3) \times 7}{2}
        // this is actually wrong lol (todo)

        var allDescendants = this.allTypesRoot.GetDescendants().Cast<TeXpression<double>>().ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(allDescendants.Count, Is.EqualTo(11));
            Assert.That(allDescendants[0], Is.InstanceOf<BinaryTeXpression<double, double, double>>());
            Assert.That(allDescendants[0].Evaluate(), Is.EqualTo(35));
            Assert.That(allDescendants[1], Is.InstanceOf<SetTeXpression<double, double>>());
            Assert.That(allDescendants[1].Evaluate(), Is.EqualTo(5));
            Assert.That(allDescendants[2], Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(allDescendants[2].Evaluate(), Is.EqualTo(5));
            Assert.That(allDescendants[3], Is.InstanceOf<BinaryTeXpression<double, double, double>>());
            Assert.That(allDescendants[3].Evaluate(), Is.EqualTo(-9));
            Assert.That(allDescendants[4], Is.InstanceOf<UnaryTeXpression<double, double>>());
            Assert.That(allDescendants[4].Evaluate(), Is.EqualTo(-4.5));
            Assert.That(allDescendants[5], Is.InstanceOf<ParameterTeXpression<double>>());
            Assert.That(allDescendants[5].Evaluate(), Is.EqualTo(4.5));
            Assert.That(allDescendants[6], Is.InstanceOf<BinaryTeXpression<double, double, double>>());
            Assert.That(allDescendants[6].Evaluate(), Is.EqualTo(2));
            Assert.That(allDescendants[7], Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(allDescendants[7].Evaluate(), Is.EqualTo(5));
            Assert.That(allDescendants[8], Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(allDescendants[8].Evaluate(), Is.EqualTo(3));
            Assert.That(allDescendants[9], Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(allDescendants[9].Evaluate(), Is.EqualTo(7));
            Assert.That(allDescendants[10], Is.InstanceOf<ConstantTeXpression<double>>());
            Assert.That(allDescendants[10].Evaluate(), Is.EqualTo(2));
        });
    }

    [Test]
    public void TryEvaluateReturnsFalseForUnsetParameterValue()
    {
        var expr = Numeric.SquareRoot(
            Numeric.Parameter("a")
        );

        var actualBool = expr.TryEvaluate(out var actualResult);

        Assert.Multiple(() =>
        {
            Assert.That(actualBool, Is.False);
            Assert.That(actualResult, Is.EqualTo(default(double)));
        });
    }

    [Test]
    public void TryEvaluateReturnsTrueForSetParameterValue()
    {
        var expectedEval = 1;
        var expr = Numeric.SquareRoot(
            Numeric.Parameter("a", Numeric.Constant(expectedEval))
        );

        var actualBool = expr.TryEvaluate(out var actualResult);

        Assert.Multiple(() =>
        {
            Assert.That(actualBool, Is.True);
            Assert.That(actualResult, Is.EqualTo(expectedEval));
        });
    }
}
