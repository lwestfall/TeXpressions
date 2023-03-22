grammar TeXpression;

@header {
#pragma warning disable 3021
}

import Logic;

statement: (
		'$' topExpr '$'
		| '\\(' topExpr '\\)'
		| '$$' topExpr '$$'
		| '\\[' topExpr '\\]'
	) EOF;

topExpr: var '=' expr | expr;

expr: logicExpr | numericExpr;
