namespace TeXpressions.Core.Common;

using System.Globalization;
using TeXpressions.Core.Formatting;
using TeXpressions.Core.Interfaces;

public abstract class TeXpression : ITeXpression
{
    public TeXpression(ILaTeXFormatter latexFormat) => this.LaTeXFormatter = latexFormat;

    public ILaTeXFormatter LaTeXFormatter { get; set; }

    public IFormatProvider FormatProvider { get; set; } = CultureInfo.CurrentCulture;

    public abstract TeXpression Simplify(ILaTeXFormatter? constantFormatter);

    public string ToLaTeX() => this.LaTeXFormatter.Format(this);
}

public abstract class TeXpression<TResult> : TeXpression
where TResult : notnull, IFormattable
{
    public TeXpression(ILaTeXFormatter latexFmt) : base(latexFmt)
    {
    }

    public abstract override TeXpression<TResult> Simplify(ILaTeXFormatter? constantFormatter);

    public ConstantTeXpression<TResult> SimplifyToConstant(ILaTeXFormatter? constantFormatter) => new(this.Evaluate(), constantFormatter ?? new ConstantLaTeXFormatter());

    public abstract TResult Evaluate();
}
