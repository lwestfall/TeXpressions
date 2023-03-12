namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Interfaces;

public class ParameterLaTeXFormatter : LaTeXFormatter<IParameterTeXpression>
{
    public override string Format(IParameterTeXpression texpression) => texpression.GetParameterLatex();
}
