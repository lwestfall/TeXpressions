namespace TeXpressions.Core.Formatting;

using TeXpressions.Core.Interfaces;

public class ConstantLaTeXFormatter : LaTeXFormatter<IConstantTeXpression>
{
    public ConstantLaTeXFormatter(string formatString = "")
    {
        this.FormatString = formatString;
        this.AllowAdjacentMultiplication = true;
    }

    public string FormatString { get; set; }

    public override string Format(IConstantTeXpression texpression) => texpression.ValueToString(this.FormatString);
}
