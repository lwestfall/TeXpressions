# Cases

Cases, or conditional expressions, allow the evaluation of an expression to change bases on the evaulation of another set of logical expressions.

## Example

Let's consider the rectified linear unit (ReLU) function, commonly used in neural networks. The ReLU function can be simply described as: take the value of x if x is positive, otherwise take 0. This can be written in LaTeX as:

$y = \begin{cases} x & \text{if } x > 0 \\ 0 & \text{otherwise} \end{cases}$

```tex
$y = \begin{cases} x & \text{if } x > 0 \\ 0 & \text{otherwise} \end{cases}$
```

## Syntax

While there are several accepted ways to write cases in LaTeX, TeXpressions must use the syntax above. That is, the cases environment must be used, and the cases must be separated by `\\` and the conditions must be separated by `&`.

The keyword `if` is optional, but is recommended for clarity, for the first case at least.

The default case is the last case, and must use the keyword `otherwise` or `else`. The default case is optional, but if omitted and no condition evaluates to true, an Exception will be thrown when trying to evaluate the TeXpression.
