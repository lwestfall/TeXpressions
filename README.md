# TeXpressions

[![codecov](https://codecov.io/gh/lwestfall/TeXpressions/branch/main/graph/badge.svg?token=UDHTYTL99C)](https://codecov.io/gh/lwestfall/TeXpressions)

TeXpressions is a framework for .NET 6+ that can do:

- (TODO) Run-time parsing of LaTeX math and logical strings
- Compile-time expression building, similar to the Linq.Expressions API
- Evaluation of expressions
- Simplification of expressions (including intermediate steps)
- (WIP) Formatting of expressions to LaTeX strings

## Disclaimer

I'm not very smart, I'm not the best programmer or software architect, I'm certainly not a great mathematician or LaTeX wizard. I wrote this in my spare time to fulfill my own niche use-case at work, while trying to generalize it enough to be helpful to others. I'm sure it can be improved and that there are mistakes. If you have suggestions or questions, please open a new issue or a discussion thread.

At the moment this code base is **highly** volatile - it is very likely to change quite a lot before I choose to release 1.0.0. Use at your own risk!

I *do not* guarantee or certify the accuracy of the LaTeX parsing, expression simplifications, evaluation, or LaTeX formatting! It is up to **you** as the consumer to independently verify that this software is sufficiently safe and accurate for your needs. See [LICENSE.txt](LICENSE.txt) for more details.

## How to Use

**TODO**

## Supported Math Expressions

There are a handful of built-in math expressions. The common operations are supported, and for practically anything else, there are Delegate expressions that allow you to perform pretty much any function of your choosing.

`TODO - code sample`

## Extensibility

**TODO**

## Why doesn't this use Linq.Expressions?

TeXpressions was never intended to replace Linq.Expressions. While some inspiration was drawn from the runtime's expression tree architecture and builder API and there is minor overlap in capabilties, TeXpressions use-cases are quite different. It is meant to be a math and logic centric expression tree builder that includes built-in LaTeX support. Not all TeXpressions have Linq.Expressions counterparts and vice-versa. Perhaps someday there could be some integration but at time of conception it doesn't seem to make sense.

## TODO

### 0.1.0 Roadmap

- Documentation
- Implement ANTLR grammar for LaTeX parsing
- Custom exceptions where it makes sense
- Built-in support for common numeric functions (trig, max, min, floor, ceiling, etc.)
- Logical / boolean expressions, numeric comparisons, Iverson bracket notation for conditional expressions
- CONTRIBUTING.md
- Issue templates
- List all LaTeX macros being used and their package dependencies
- Demo web application

### 1.0.0 Roadmap

- Iterables (sums, etc.)
- SigFigLaTeXFormatter
- How to handle rounding error - should number rounding in simplifications cascade to future steps? Make it configurable?
- CI / CD workflows
