namespace TeXpressions.Core.Interfaces;

public interface IConstantTeXpression : ITeXpression
{
    string ValueToString(string? format);
}
