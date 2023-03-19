namespace TeXpressions.Core.Interfaces;

public interface IConstantTeXpression : ITeXpression, ILeafTeXpression
{
    string ValueToString(string? format);
}
