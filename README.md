# TeXpressions

[![codecov](https://codecov.io/gh/lwestfall/TeXpressions/branch/main/graph/badge.svg?token=UDHTYTL99C)](https://codecov.io/gh/lwestfall/TeXpressions)

TeXpressions is a framework for .NET 6+ that can do:

- Run-time parsing of LaTeX math and logical strings
- Compile-time expression building, similar to the Linq.Expressions API
- Evaluation of expressions
- Simplification of expressions (including intermediate steps)
- Formatting of expressions to LaTeX strings

## Contributing

I encourage members of the community, regardless of experience level, to participate in the design and implementation of this software. All new contributors should read the [contributing guidelines](CONTRIBUTING.md). Good candidates for first time contributors [can be found in the issues tab](https://github.com/lwestfall/TeXpressions/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22).

Please don't forget to comment in an issue (or create a new issue) *prior* to submitting a pull request. This makes it easier for other contributors to know what's being worked on.

## How to Use

**TODO**.

## Extensibility

**TODO**.

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
