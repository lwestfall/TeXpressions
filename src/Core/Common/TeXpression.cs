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

    public abstract ITeXpression[] GetChildren();

    public ITeXpression[] GetDescendants()
    {
        var children = this.GetChildren();
        var descendants = new List<ITeXpression>();

        foreach (var child in children)
        {
            descendants.Add(child);
            descendants.AddRange(child.GetDescendants());
        }

        return descendants.ToArray();
    }

    public virtual bool CanEvaluate() => this.GetDescendants().All(t => t.CanEvaluate());

}

public abstract class TeXpression<TResult> : TeXpression
where TResult : IFormattable
{
    public TeXpression(ILaTeXFormatter latexFmt) : base(latexFmt)
    {
    }

    public abstract override TeXpression<TResult> Simplify(ILaTeXFormatter? constantFormatter);

    public ConstantTeXpression<TResult> SimplifyToConstant(ILaTeXFormatter? constantFormatter = null) => new(this.Evaluate(), constantFormatter ?? new ConstantLaTeXFormatter());

    public abstract TResult Evaluate();

    public bool TryEvaluate(out TResult? result)
    {
        result = default;

        if (!this.CanEvaluate())
        {
            return false;
        }

        result = this.Evaluate();
        return true;
    }
}
