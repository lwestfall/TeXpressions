namespace TeXpressions.Parsing;

using Antlr4.Runtime;

public static class ParseUtility
{
    public static TeXpressionMathParser GetParserForInput(string input)
    {
        var charStream = new AntlrInputStream(input);
        var lexer = new TeXpressionMathLexer(charStream);
        var tokenStream = new CommonTokenStream(lexer);
        return new TeXpressionMathParser(tokenStream);
    }
}
