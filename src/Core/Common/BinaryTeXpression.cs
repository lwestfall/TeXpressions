namespace TeXpressions.Core.Common;

using TeXpressions.Core.Interfaces;

public class BinaryTeXpression<TResultLeft, TResultRight, TResultOuter> : TeXpression<TResultOuter>, IBinaryTeXpression
where TResultOuter : notnull, IFormattable
where TResultLeft : notnull, IFormattable
where TResultRight : notnull, IFormattable
{
    public BinaryTeXpression(
        TeXpression<TResultLeft> left,
        TeXpression<TResultRight> right,
        Func<TResultLeft, TResultRight, TResultOuter> function,
        ILaTeXFormatter latexFmt) : base(latexFmt)
    {
        this.Left = left;
        this.Right = right;
        this.Function = function;
    }

    public Func<TResultLeft, TResultRight, TResultOuter> Function { get; }

    public TeXpression<TResultLeft> Left { get; }

    public TeXpression<TResultRight> Right { get; }

    TeXpression IBinaryTeXpression.Left => this.Left;

    TeXpression IBinaryTeXpression.Right => this.Right;

    public override TResultOuter Evaluate() => this.Function(this.Left.Evaluate(), this.Right.Evaluate());

    public override TeXpression<TResultOuter> Simplify(ILaTeXFormatter? constantFormatter = null)
    {
        if (this.Left is IConstantTeXpression && this.Right is IConstantTeXpression)
        {
            return this.SimplifyToConstant(constantFormatter);
        }

        return new BinaryTeXpression<TResultLeft, TResultRight, TResultOuter>(
            this.Left.Simplify(constantFormatter),
            this.Right.Simplify(constantFormatter),
            this.Function,
            this.LaTeXFormatter);
    }

    public override ITeXpression[] GetChildren() => new TeXpression[] { this.Left, this.Right };
}
