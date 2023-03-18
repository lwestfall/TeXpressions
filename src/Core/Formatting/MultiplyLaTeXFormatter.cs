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
        var left = texpression.Left;
        var right = texpression.Right;
        var leftLatex = left.ToLaTeX();
        var rightLatex = right.ToLaTeX();

        if (
            !this.SmartFormatting ||
            left.LaTeXFormatter is not LaTeXFormatter leftFormatter ||
            !leftFormatter.AllowAdjacentMultiplication ||
            right.LaTeXFormatter is not LaTeXFormatter rightFormatter ||
            !rightFormatter.AllowAdjacentMultiplication
        )
        {
            return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
        }

        // todo - fix smart formatting
        if (left is IConstantTeXpression)
        {
            if (right is IConstantTeXpression)
            {
                return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
            }

            return $"{leftLatex} {rightLatex}";
        }
        else if (right is IConstantTeXpression)
        {
            return $"{leftLatex} {rightLatex}";
        }

        return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
    }

    private string GetFormatStringFromMultiplyStyle(string left, string right)
    {
        return this.Style switch
        {
            MultiplyStyle.Times => $"{left} \\times {right}",
            MultiplyStyle.Dot => $"{left} \\dot {right}",
            MultiplyStyle.ParenthesesBoth => $"({left}) ({right})",
            MultiplyStyle.ParenthesesLeftOnly => $"({left}) {right}",
            MultiplyStyle.ParenthesesRightOnly => $"{left} ({right})",
            _ => throw new NotImplementedException($"MultiplyStyle {this.Style} not implemented!"),
        };
    }
}

public enum MultiplyStyle
{
    Times,
    Dot,
    ParenthesesBoth,
    ParenthesesLeftOnly,
    ParenthesesRightOnly,
}
