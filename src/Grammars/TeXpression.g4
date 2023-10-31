grammar TeXpression;

@header {
#pragma warning disable 3021
}

import Environment;

statement: (
		'$' topExpr '$'
		| '\\(' topExpr '\\)'
		| '$$' topExpr '$$'
		| '\\[' topExpr '\\]'
	) EOF;

topExpr: var '=' expr | expr;

expr: baseExpr | envBlock;
