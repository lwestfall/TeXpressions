namespace TeXpressions.Core.Interfaces;

public interface ITeXpression
{
    IFormatProvider FormatProvider { get; }

    ILaTeXFormatter LaTeXFormatter { get; }

    string ToLaTeX();
}
