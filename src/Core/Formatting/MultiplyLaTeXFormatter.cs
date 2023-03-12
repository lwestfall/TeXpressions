namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Interfaces;

public class MultiplyLaTeXFormatter : LaTeXFormatter<IBinaryTeXpression>
{
    public MultiplyLaTeXFormatter(MultiplyStyle style = MultiplyStyle.Times, bool smartFormat = true)
    {
        this.Style = style;
        this.SmartFormatting = smartFormat;
        this.AllowAdjacentMultiplication = this.SmartFormatting;
    }

    public MultiplyStyle Style { get; set; }

    public bool SmartFormatting { get; set; }

    public override string Format(IBinaryTeXpression texpression)
    {
        if (texpression is not IBinaryTeXpression binTexpr)
        {
            throw new InvalidOperationException($"Cannot use {nameof(MultiplyLaTeXFormatter)} as format for {texpression.GetType().Name}");
        }

        var leftLatex = binTexpr.Left.ToLaTeX();
        var rightLatex = binTexpr.Right.ToLaTeX();

        if (
            !this.SmartFormatting ||
            binTexpr.Left.LaTeXFormatter is not LaTeXFormatter leftFormatter ||
            !leftFormatter.AllowAdjacentMultiplication ||
            binTexpr.Right.LaTeXFormatter is not LaTeXFormatter rightFormatter ||
            !rightFormatter.AllowAdjacentMultiplication
        )
        {
            return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
        }

        // todo - fix smart formatting
        if (binTexpr.Left is IConstantTeXpression)
        {
            if (binTexpr.Right is IConstantTeXpression)
            {
                return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
            }

            return $"{{{leftLatex}}} {{{rightLatex}}}";
        }
        else if (binTexpr.Right is IConstantTeXpression)
        {
            return $"{{{rightLatex}}} {{{leftLatex}}}";
        }

        return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
    }

    private string GetFormatStringFromMultiplyStyle(string left, string right)
    {
        return this.Style switch
        {
            MultiplyStyle.Times => $"{{{left}}} \\times {{{right}}}",
            MultiplyStyle.Dot => $"{{{left}}} \\dot {right}",
            MultiplyStyle.ParenthesesBoth => $"({left}) ({right})",
            MultiplyStyle.ParenthesesLeftOnly => $"({left}) {right}",
            MultiplyStyle.ParenthesesRightOnly => $"{left} ({right})",
            _ => throw new NotImplementedException($"MultiplyStyle {this.Style} not implemented!"),
        };
    }

    public static MultiplyLaTeXFormatter Default { get; set; } = new(MultiplyStyle.Times, true);
}

public enum MultiplyStyle
{
    Times,
    Dot,
    ParenthesesBoth,
    ParenthesesLeftOnly,
    ParenthesesRightOnly,
}
