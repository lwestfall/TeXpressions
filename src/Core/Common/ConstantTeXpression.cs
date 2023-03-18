namespace TeXpressions.Core.Common;

using TeXpressions.Core.Interfaces;

public class ConstantTeXpression<TResult> : TeXpression<TResult>, IConstantTeXpression
where TResult : notnull, IFormattable
{
    public ConstantTeXpression(TResult value, ILaTeXFormatter latexFmt) : base(latexFmt) => this.Value = value;

    public TResult Value { get; }

    public override TResult Evaluate() => this.Value;

    public override TeXpression<TResult> Simplify(ILaTeXFormatter? constantFormatter = null)
    {
        if (constantFormatter != null)
        {
            this.LaTeXFormatter = constantFormatter;
        }

        return this;
    }

    public string ValueToString(string? format = null) => this.Value.ToString(format, this.FormatProvider);
}
