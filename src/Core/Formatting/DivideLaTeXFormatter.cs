namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Interfaces;

public class DivideLaTeXFormatter : LaTeXFormatter<IBinaryTeXpression>
{
    public DivideLaTeXFormatter(DivideStyle style = DivideStyle.StandardFraction)
    {
        this.Style = style;
        this.AllowAdjacentMultiplication = style is DivideStyle.StandardFraction or DivideStyle.SlantedFraction;
    }

    public DivideStyle Style { get; set; }

    public override string Format(IBinaryTeXpression texpression)
    {
        var leftLatex = texpression.Left.ToLaTeX();
        var rightLatex = texpression.Right.ToLaTeX();

        return this.Style switch
        {
            DivideStyle.StandardFraction => @$"\frac{{{leftLatex}}}{{{rightLatex}}}",
            DivideStyle.SlantedFraction => @$"\sfrac{{{leftLatex}}}{{{rightLatex}}}",
            DivideStyle.Slash => $"{{{leftLatex}}} / {{{rightLatex}}}",
            _ => throw new NotImplementedException($"DivideStyle {this.Style} not implemented!"),
        };
    }
}

public enum DivideStyle
{
    StandardFraction,
    SlantedFraction,
    Slash
}
