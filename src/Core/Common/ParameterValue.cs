namespace TeXpressions.Core.Common;

using TeXpressions.Core.Formatting;
using TeXpressions.Core.Interfaces;

public class ParameterValue<TValue>
where TValue : notnull
{
    public ParameterValue(string latex, TeXpression<TValue>? valExpr = null)
    {
        this.LaTeXName = latex;
        this.ValueExpression = valExpr;
    }

    public string LaTeXName { get; set; }

    public TeXpression<TValue>? ValueExpression { get; set; }

    public ParameterTeXpression<TValue> GetNewTeXpression(ILaTeXFormatter? formatter = null)
        => new(this, formatter ?? new ParameterLaTeXFormatter());
}
