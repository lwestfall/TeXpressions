namespace TeXpressions.Core.Interfaces;

public interface IConstantTeXpression : ITeXpression
{
    object Value { get; }

    string ValueToString(string? format);
}
