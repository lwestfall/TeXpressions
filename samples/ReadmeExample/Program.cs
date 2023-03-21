using TeXpressions.Core;
using TeXpressions.Core.Common;
using TeXpressions.Parsing;

/*
    See readme.md for more explanation of what's happening here.
*/

var texpr = ParseUtility.ParseInlineExpression<TeXpression<double>>(@"$\frac{2 \times 10}{4}$");
// the @ before the string makes it a verbatim string, so backslash \ doesn't get escaped
// slightly cleaner than the alternative "$\\frac{2 \\times 10}{4}$" :)

Console.WriteLine($"The expression back to inline LaTeX: ${texpr.ToLaTeX()}$");
Console.WriteLine($"And it evaluates to: {texpr.Evaluate()}");

/* Output
The expression back to inline LaTeX: $\frac{2 \times 10}{4}$
And it evaluates to: 5
*/
Console.WriteLine();


var texpr2 = Numeric.Divide(    // Root: BinaryTeXpression
    Numeric.Multiply(           // Root.Left: BinaryTeXpression
        Numeric.Constant(2),    // Root.Left.Left: ConstantTeXpression
        Numeric.Constant(10)   // Root.Left.Right: ConstantTeXpression
    ),
    Numeric.Constant(4)         // Root.Right: ConstantTeXpression
);

Console.WriteLine($"texpr2 back to inline LaTeX: ${texpr2.ToLaTeX()}$");
Console.WriteLine($"This one evaluates to: {texpr2.Evaluate()}");

/* Output
texpr2 back to inline LaTeX: $\frac{2 \times 10}{4}$
This one evaluates to: 5
*/
