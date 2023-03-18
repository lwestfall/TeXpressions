namespace TeXpressions.Core.Interfaces;
using TeXpressions.Core.Common;

public interface IBinaryTeXpression : ITeXpression, IParentTeXpression
{
    TeXpression Left { get; }
    TeXpression Right { get; }
}
