namespace TeXpressions.Core.Interfaces;

using TeXpressions.Core.Common;

public interface IUnaryTeXpression : ITeXpression
{
    TeXpression Inner { get; }
}
