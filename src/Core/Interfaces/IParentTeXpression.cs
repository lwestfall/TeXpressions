namespace TeXpressions.Core.Interfaces;
public interface IParentTeXpression : ITeXpression
{
    ITeXpression[] GetChildren();

    ITeXpression[] GetDescendants();
}
