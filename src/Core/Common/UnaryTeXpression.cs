namespace TeXpressions.Core.Common;

using TeXpressions.Core.Interfaces;

public class UnaryTeXpression<TResultInner, TResultOuter> : TeXpression<TResultOuter>, IUnaryTeXpression
where TResultOuter : notnull
where TResultInner : notnull
{
    public UnaryTeXpression(
        TeXpression<TResultInner> inner,
        Func<TResultInner, TResultOuter> function,
        ILaTeXFormatter latexFmt) : base(latexFmt)
    {
        this.Inner = inner;
        this.Function = function;
    }

    public Func<TResultInner, TResultOuter> Function { get; protected set; }

    public TeXpression<TResultInner> Inner { get; }

    TeXpression IUnaryTeXpression.Inner => this.Inner;

    public override TResultOuter Evaluate() => this.Function(this.Inner.Evaluate());

    public override ITeXpression[] GetChildren() => new[] { this.Inner };

    public override TeXpression<TResultOuter> Simplify(ILaTeXFormatter? constantFormatter = null)
    {
        if (this.Inner is ConstantTeXpression<TResultInner>)
        {
            return this.SimplifyToConstant(constantFormatter);
        }

        return new UnaryTeXpression<TResultInner, TResultOuter>(this.Inner.Simplify(constantFormatter), this.Function, this.LaTeXFormatter);
    }
}
