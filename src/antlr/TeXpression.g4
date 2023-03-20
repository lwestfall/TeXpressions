grammar TeXpression;
import Logic;

inline: ('$' topExpr '$' | '\\(' topExpr '\\)') EOF;

topExpr: var '=' expr | expr;

expr: numericExpr | logicExpr;
