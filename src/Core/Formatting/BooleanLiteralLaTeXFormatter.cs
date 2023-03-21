namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Common;

public class BooleanLiteralLaTeXFormatter : LaTeXFormatter<ConstantTeXpression<bool>>
{
    public override string Format(ConstantTeXpression<bool> texpression) => texpression.Value ? @"\top" : @"\bot";
}
