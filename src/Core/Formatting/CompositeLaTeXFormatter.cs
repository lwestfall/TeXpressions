namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Common;
using TeXpressions.Core.Interfaces;

public class CompositeLaTeXFormatter : LaTeXFormatter
{
    public CompositeLaTeXFormatter(string format) => this.FormatString = format;

    public string FormatString { get; }

    public override string Format(TeXpression texpression)
    {
        if (texpression is IUnaryTeXpression unary)
        {
            return string.Format(texpression.FormatProvider, this.FormatString, unary.Inner.ToLaTeX());
        }
        if (texpression is IBinaryTeXpression binary)
        {
            return string.Format(texpression.FormatProvider, this.FormatString, binary.Left.ToLaTeX(), binary.Right.ToLaTeX());
        }
        if (texpression is ISetTeXpression set)
        {
            return string.Format(texpression.FormatProvider, this.FormatString, string.Join(", ", set.Inners.Select(i => i.ToLaTeX())));
        }

        throw new NotImplementedException($"{nameof(Format)} doesn't know how to format {texpression.GetType().Name}!");
    }
}
