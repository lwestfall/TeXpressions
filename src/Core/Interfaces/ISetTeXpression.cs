namespace TeXpressions.Core.Interfaces;

using TeXpressions.Core.Common;

public interface ISetTeXpression : ITeXpression
{
    TeXpression[] Inners { get; }
}
