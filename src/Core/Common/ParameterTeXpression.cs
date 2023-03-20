namespace TeXpressions.Core.Common;

using TeXpressions.Core.Formatting;
using TeXpressions.Core.Interfaces;

public class ParameterTeXpression<TResult> : TeXpression<TResult>, IParameterTeXpression
where TResult : notnull
{
    public ParameterTeXpression(ParameterValue<TResult> parameterValue, ILaTeXFormatter? latexFmt) : base(latexFmt ?? new ParameterLaTeXFormatter())
        => this.ParameterValue = parameterValue;

    public ParameterValue<TResult> ParameterValue { get; set; }

    public override TResult Evaluate()
    {
        if (this.ParameterValue.ValueExpression != null)
        {
            return this.ParameterValue.ValueExpression.Evaluate();
        }

        throw new InvalidOperationException($"Tried to evaluate unset parameter {this.ToLaTeX()}");
    }

    public override ITeXpression[] GetChildren() => Array.Empty<ITeXpression>();

    public string GetParameterLatex() => this.ParameterValue.LaTeXName;

    public override TeXpression<TResult> Simplify(ILaTeXFormatter? constantFormatter = null) => this.SimplifyToConstant(constantFormatter);

    public override bool CanEvaluate() => this.ParameterValue.ValueExpression?.CanEvaluate() ?? false;
}
