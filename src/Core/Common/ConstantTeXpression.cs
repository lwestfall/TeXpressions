namespace TeXpressions.Core.Common;

using TeXpressions.Core.Interfaces;

public class ConstantTeXpression<TResult> : TeXpression<TResult>, IConstantTeXpression
where TResult : notnull
{
    public ConstantTeXpression(TResult value, ILaTeXFormatter latexFmt) : base(latexFmt) => this.Value = value;

    public TResult Value { get; }

    public override TResult Evaluate() => this.Value;

    public override ITeXpression[] GetChildren() => Array.Empty<ITeXpression>();

    public override TeXpression<TResult> Simplify(ILaTeXFormatter? constantFormatter = null)
    {
        if (constantFormatter != null)
        {
            this.LaTeXFormatter = constantFormatter;
        }

        return this;
    }

    public string ValueToString(string? format = null)
    {
        if (this.Value is IFormattable formattable)
        {
            return formattable.ToString(format, this.FormatProvider);
        }
        else
        {
            return this.Value.ToString() ?? throw new InvalidOperationException("ToString() returning null??");
        }
    }
}
