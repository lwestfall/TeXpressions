grammar LaTeX_old;

prog: assign EOF;

funcCall: FUNCTION '(';

exprList:
	expr (',' expr)*
	| matrixStart matrixRowCommaDelimited matrixEnd;

number: DIGIT* '.' DIGIT+ | DIGIT+;
id: LETTER (DIGIT | LETTER)* | '{' id '}';
constant: '\\pi';

desc: (DIGIT | LETTER | '-' | ',' | FUNCTION)+;
subscript: '_{' desc '}' | '_' (DIGIT | LETTER);
varMod: '\\bar';
var: varMod '{' id '}' subscript? | id subscript?;
stringLiteral: '"' .*? '"' | '\'' .*? '\'';

assign: var '=' expr;

matrixStart: '\\begin{matrix}';
matrixEnd: '\\end{matrix}';
matrix: matrixStart matrixRow+ matrixEnd;

matrixRow: expr ('&' expr)* '\\\\';
matrixRowCommaDelimited: expr (',' '&' expr)* '\\\\';

lessThan: '<';
lessThanEqual: '\\le' 'q'? | '<=';
greaterThan: '>';
greaterThanEqual: '\\ge' 'q'? | '>=';

comparison:
	lessThan
	| lessThanEqual
	| greaterThan
	| greaterThanEqual;

expr:
	exprGroup
	| number
	| var
	| constant
	| expr exprGroup
	| exprGroup expr
	| expr '^' expr
	| expr '^{' expr '}'
	| (number | constant) expr
	| expr ('*' | '\\ast' | '\\times' | '/' | '\\dot') expr
	| expr ('+' | '-') expr
	| expr comparison expr;

exprFunc1: '\\sqrt';

exprFunc2: '\\frac' | '\\sfrac';

exprGroup:
	funcCall exprList ')'
	| '(' expr ')'
	| '[' expr ']'
	| exprFunc1 exprParam
	| exprFunc2 exprParam exprParam
	| exprParam
	| matrix;

exprParam: '{' expr '}';

FUNCTION: 'max' | 'min';

LETTER: GREEK | [a-zA-Z];
DIGIT: [0-9];
WS: ('\\'? ' ' | [\t\r\n])+ -> skip; // skip spaces, tabs, newlines
MISC_SKIP: ('\\left' | '\\right' '.'?) -> skip;

fragment GREEK:
	[\u0391-\u03C9]
	| '\\alpha'
	| '\\beta'
	| '\\delta'
	| '\\phi'
	| '\\sigma'
	| '\\tau'
	| '\\lambda'
	| '\\omega';
