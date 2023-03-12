namespace TeXpressions.Core.Interfaces;
using TeXpressions.Core.Common;

public interface IBinaryTeXpression : ITeXpression
{
    TeXpression Left { get; }
    TeXpression Right { get; }
}
