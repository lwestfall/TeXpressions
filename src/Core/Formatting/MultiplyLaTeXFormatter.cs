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

        if (!this.SmartFormatting || !CanDoAdjacent(binTexpr.Left) || !CanDoAdjacent(binTexpr.Right))
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

            var leftOfRight = binTexpr.Right;

            // go down the left side of the expression subtree on the right
            // check if we encounter cases where we can't do adjacent multiply
            while (leftOfRight is IBinaryTeXpression binLeftOfRight)
            {
                if (binLeftOfRight.Left is IConstantTeXpression || !CanDoAdjacent(binLeftOfRight.Left))
                {
                    return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
                }

                leftOfRight = binLeftOfRight.Left;
            }

            return $"{{{leftLatex}}} {{{rightLatex}}}";
        }
        else if (binTexpr.Right is IConstantTeXpression)
        {
            var rightOfLeft = binTexpr.Left;

            // go down the right side of the expression subtree on the left
            // check if we encounter cases where we can't do adjacent multiply
            while (rightOfLeft is IBinaryTeXpression binRightOfLeft)
            {
                if (binRightOfLeft.Right is IConstantTeXpression || !CanDoAdjacent(binRightOfLeft.Right))
                {
                    return this.GetFormatStringFromMultiplyStyle(leftLatex, rightLatex);
                }

                rightOfLeft = binRightOfLeft.Right;
            }
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

    private static bool CanDoAdjacent(ITeXpression texpr)
    {
        var adjacent = texpr.LaTeXFormatter is LaTeXFormatter formatter &&
            formatter.AllowAdjacentMultiplication;

        return adjacent;
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
