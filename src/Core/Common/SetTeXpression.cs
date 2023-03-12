namespace TeXpressions.Core.Common;

using TeXpressions.Core.Interfaces;

public class SetTeXpression<TResultInner, TResultOuter> : TeXpression<TResultOuter>, ISetTeXpression
where TResultOuter : notnull, IFormattable
where TResultInner : notnull, IFormattable
{
    public SetTeXpression(TeXpression<TResultInner>[] inners, Func<TResultInner[], TResultOuter> function, ILaTeXFormatter latexFmt) : base(latexFmt)
    {
        this.Inners = inners;
        this.Function = function;
    }

    public TeXpression<TResultInner>[] Inners { get; }

    public Func<TResultInner[], TResultOuter> Function { get; }

    TeXpression[] ISetTeXpression.Inners => this.Inners;

    public override TResultOuter Evaluate() => this.Function(this.Inners.Select(t => t.Evaluate()).ToArray());

    public override TeXpression<TResultOuter> Simplify(ILaTeXFormatter? constantFormatter)
    {
        if (this.Inners.All(t => t is ConstantTeXpression<TResultInner>))
        {
            return this.SimplifyToConstant(constantFormatter);
        }

        var simplifiedInners = this.Inners.Select(t => t.Simplify(constantFormatter)).ToArray();

        return new SetTeXpression<TResultInner, TResultOuter>(simplifiedInners, this.Function, this.LaTeXFormatter);
    }
}
