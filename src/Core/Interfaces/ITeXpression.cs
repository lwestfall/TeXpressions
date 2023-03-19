namespace TeXpressions.Core.Interfaces;

public interface ITeXpression
{
    IFormatProvider FormatProvider { get; }

    bool CanEvaluate();

    ITeXpression[] GetChildren();

    ITeXpression[] GetDescendants();
}
