grammar TeXpression;

@header {
#pragma warning disable 3021
}

import Logic;

inline: ('$' topExpr '$' | '\\(' topExpr '\\)') EOF;

topExpr: var '=' expr | expr;

expr: logicExpr | numericExpr;
