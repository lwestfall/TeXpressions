namespace TeXpressions.Parsing;

using Antlr4.Runtime;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Visitors;

public static class ParseUtility
{
    public static TeXpressionParser GetParserForInput(string input)
    {
        var charStream = new AntlrInputStream(input);
        var lexer = new TeXpressionLexer(charStream);
        var tokenStream = new CommonTokenStream(lexer);
        return new TeXpressionParser(tokenStream);
    }

    public static TeXpression ParseInlineExpression(string input)
    {
        var parser = GetParserForInput(input);
        var ctx = parser.inline();
        var visitor = new TeXpressionVisitor();
        return visitor.Visit(ctx);
    }

    public static TTeXpression ParseInlineExpression<TTeXpression>(string input)
    where TTeXpression : TeXpression
    {
        var parser = GetParserForInput(input);
        var ctx = parser.inline();
        var visitor = new TeXpressionVisitor();
        return (TTeXpression)visitor.Visit(ctx);
    }
}
