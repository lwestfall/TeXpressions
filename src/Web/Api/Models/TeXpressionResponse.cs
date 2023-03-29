namespace TeXpressions.Api.Models;

using Antlr4.Runtime;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Visitors;

public class TeXpressionResponse
{
    public TeXpressionResponse(string latex)
    {
        var charStream = new AntlrInputStream(latex);
        var lexer = new TeXpressionLexer(charStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new TeXpressionParser(tokenStream);

        var ctx = parser.statement();

        if (ctx == null)
        {
            this.Errors.Add("TeXpression parsing failed.");
            return;
        }

        var visitor = new TeXpressionVisitor();
        TeXpression? texpr = null;

        try
        {
            texpr = visitor.Visit(ctx);
        }
        catch (Exception e)
        {
            this.Errors.Add("TeXpression building failed with exception. ");
            this.Errors.Add(e.ToString());
            return;
        }

        if (texpr == null)
        {
            this.Errors.Add("TeXpression building failed.");
            return;
        }

        this.Formatted = texpr.ToLaTeX();
        this.CanEvaluate = texpr.CanEvaluate();

        if (this.CanEvaluate)
        {
            this.Evaluated = texpr.EvaluateToObject().ToString();
        }
    }

    public string? Formatted { get; set; }

    public bool CanEvaluate { get; set; }

    public string? Evaluated { get; set; }

    public List<string> Messages { get; set; } = new List<string>();

    public List<string> Errors { get; set; } = new List<string>();
}
