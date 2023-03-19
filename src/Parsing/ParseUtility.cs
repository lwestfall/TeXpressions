namespace TeXpressions.Parsing;

using Antlr4.Runtime;
using TeXpressions.Core.Common;
using TeXpressions.Parsing.Visitors;

public static class ParseUtility
{
    public static TeXpressionMathParser GetParserForInput(string input)
    {
        var charStream = new AntlrInputStream(input);
        var lexer = new TeXpressionMathLexer(charStream);
        var tokenStream = new CommonTokenStream(lexer);
        return new TeXpressionMathParser(tokenStream);
    }

    public static TeXpression<double> ParseInlineNumericExpression(string input)
    {
        var parser = GetParserForInput(input);
        var ctx = parser.inlineMath();
        var visitor = new NumericTeXpressionVisitor();
        return visitor.Visit(ctx);
    }
}
