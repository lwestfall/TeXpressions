namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Common;
using TeXpressions.Core.Interfaces;

public abstract class LaTeXFormatter : ILaTeXFormatter
{
    public bool AllowAdjacentMultiplication { get; set; }

    public abstract string Format(TeXpression texpression);
}

public abstract class LaTeXFormatter<TTeXpression> : LaTeXFormatter
{
    public abstract string Format(TTeXpression texpression);

    public override string Format(TeXpression texpression)
    {
        if (texpression is not TTeXpression typeOfTexpr)
        {
            throw new InvalidOperationException($"Cannot use {this.GetType().Name} as formatter for TeXpression {texpression.GetType().Name}!");
        }

        return this.Format(typeOfTexpr);
    }
}
