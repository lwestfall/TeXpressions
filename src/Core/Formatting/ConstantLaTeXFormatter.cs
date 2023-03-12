namespace TeXpressions.Core.Formatting;

using System.Globalization;
using TeXpressions.Core.Interfaces;

public class ConstantLaTeXFormatter : LaTeXFormatter<IConstantTeXpression>
{
    public ConstantLaTeXFormatter(string formatString = "")
    {
        this.FormatString = formatString;
        this.AllowAdjacentMultiplication = true;
    }

    public string FormatString { get; set; }

    public IFormatProvider FormatProvider { get; set; } = CultureInfo.CurrentCulture;

    public override string Format(IConstantTeXpression texpression) => texpression.ToString(this.FormatString, this.FormatProvider);
}
