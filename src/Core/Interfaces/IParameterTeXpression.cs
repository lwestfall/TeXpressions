namespace TeXpressions.Core.Interfaces;

public interface IParameterTeXpression : ITeXpression, ILeafTeXpression
{
    string GetParameterLatex();
}
