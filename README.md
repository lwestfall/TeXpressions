# TeXpressions

[![codecov](https://codecov.io/gh/lwestfall/TeXpressions/branch/main/graph/badge.svg?token=UDHTYTL99C)](https://codecov.io/gh/lwestfall/TeXpressions)

TeXpressions is a framework for .NET 6+ that can do:

- Run-time parsing of LaTeX math and logical strings
- Compile-time expression building, similar to the Linq.Expressions API
- Evaluation of expressions
- Simplification of expressions (including intermediate steps)
- Formatting of expressions to LaTeX strings

## Contributing

I encourage members of the community, regardless of experience level, to participate in the design and implementation of this software. All new contributors should read the [contributing guidelines](CONTRIBUTING.md). Good candidate issues for first time contributors [can be found in the issues tab](https://github.com/lwestfall/TeXpressions/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22).

Please don't forget to comment in an issue (or create a new issue) *prior* to submitting a pull request. This makes it easier for other contributors to know what's being worked on.

## How to Use

There are two primary ways to build TeXpression trees. All of the code in the following two sections can be found and run yourself from [samples/ReadmeExample/Program.cs](samples/ReadmeExample/Program.cs).

What you see below is just the most basic explanation. See the wiki for more details and features.

### 1. Parsing LaTeX strings

The "more powerful" method of building TeXpressions is feeding it LaTeX strings. These are parsed into their respective TeXpression trees. Let's look at an example:

`$\frac{2 \times 10}{4}$` which renders to $\frac{2 \times 10}{4}$ Using some mental math, we can quickly see that this should evaluate to 5.

We can easily parse it to a variable called `texpr` like this:

```cs
var texpr = ParseUtility.ParseInlineNumericExpression(@"$\frac{2 \times 10}{4}$");
// the @ before the string makes it a verbatim string, so backslash \ doesn't get escaped
// slightly cleaner than the alternative "$\\frac{2 \\times 10}{4}$" :)
```

How will this get parsed? It might be easier to explain with an image of the resulting tree:

Hopefully it's pretty clear what's happening here:

- The "outer" or "top" most TeXpression is a `BinaryTeXpression` representing the `\frac` LaTeX function.
  - The dividend (a.k.a. numerator) is the root's "Left" inner TeXpression, and is another `BinaryTeXpression`, but this time for the `\times` operator. Being a `BinaryTeXpression`, it has a `Left` and `Right` of its own:
    - The Left is a `ConstantTeXpression` with value 2.
    - The Right is a `ConstantTeXpression` with value 10.
  - The divisor is the "Right" TeXpression and is a `ConstantTeXpression` with a value of 4.

Great, we have a TeXpression tree! What can we do with it? Well, we can turn it back into LaTeX which is nice:

```cs
Console.WriteLine($"The expression back to inline LaTeX: ${texpr.ToLaTeX()}$");
```

We can also evaluate the TeXpression because there's no unknown parameters:

```cs
Console.WriteLine($"And it evaluates to: ${texpr.Evaluate()}$");
```

Here is the resulting output for both lines:

> The expression back to inline LaTeX: $\frac{2 \times 10}{4}$
> And it evaluates to: 5

Not bad!

### 2. Using built-in builder APIs

Okay, so we just saw how the parser can turn an inline LaTeX expression and turn it into a TeXpression tree. What if we wanted to build this at design time?

The built-in Numeric static class is great for building TeXpression trees for common math functions, and working with the double value-type. Let's make the above example using the Numeric API:

```cs
var texpr2 = Numeric.Divide(    // Root: BinaryTeXpression
    Numeric.Multiply(           // Root.Left: BinaryTeXpression
        Numeric.Constant(2),    // Root.Left.Left: ConstantTeXpression
        Numeric.Constant(10)    // Root.Left.Right: ConstantTeXpression
    ),
    Numeric.Constant(4)         // Root.Right: ConstantTeXpression
);
```

Let's format the LaTeX string and evaluate this one. Hopefully it all comes out the same:

```cs
Console.WriteLine($"texpr2 back to inline LaTeX: ${texpr2.ToLaTeX()}$");
Console.WriteLine($"This one evaluates to: ${texpr2.Evaluate()}$");
```

And the resulting output:

> texpr2 back to inline LaTeX: $\frac{2 \times 10}{4}$
> This one evaluates to: 5

It looks like it matches, phew!

## Extensibility

None of the classes in this library are sealed so you're free to create your own inherited classes for your own use-case.

Please open a new issue if you want to merge your implementation to this library! It should be common enough to benefit others, so please keep that in mind before submitting.

## Why doesn't this use Linq.Expressions?

TeXpressions was never intended to replace Linq.Expressions. While some inspiration was drawn from the runtime's expression tree architecture and builder API and there is minor overlap in capabilties, TeXpressions use-cases are quite different. It is meant to be a math and logic centric expression tree builder that includes built-in LaTeX support. Not all TeXpressions have Linq.Expressions counterparts and vice-versa. Perhaps someday there could be some integration but at time of conception it doesn't seem to make sense.

## 1.0.0 Roadmap

- Iterables (sums, etc.)
- SigFigLaTeXFormatter
- How to handle rounding error - should number rounding in simplifications cascade to future steps? Make it configurable?

## Disclaimer

I'm not very smart, I'm not the best programmer or software architect, I'm certainly not a great mathematician or LaTeX wizard. I wrote this in my spare time to fulfill my own niche use-case at work, while trying to generalize it enough to be helpful to others. I'm sure it can be improved and that there are mistakes. If you have suggestions or questions, please open a new issue or a discussion thread.

At the moment this code base is **highly** volatile - it is very likely to change quite a lot before I choose to release 1.0.0. Use at your own risk!

I *do not* guarantee or certify the accuracy of the LaTeX parsing, expression simplifications, evaluation, or LaTeX formatting! It is up to **you** as the consumer to independently verify that this software is sufficiently safe and accurate for your needs. See [LICENSE.txt](LICENSE.txt) for more details.

## References

<a id="1">[1]</a>
Downes, Michael, and Barbara Beeton.
“Short Math Guide for LATEX."
<http://mirror.ctan.org/info/short-math-guide>

<a id="2">[2]</a>
"LaTeX/Mathematics."
Wikibooks, The Free Textbook Project.
25 Oct 2022, 10:02 UTC. 16 Mar 2023, 09:48
<https://en.wikibooks.org/w/index.php?title=LaTeX/Mathematics&oldid=4197055>.
