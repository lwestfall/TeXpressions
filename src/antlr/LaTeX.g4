grammar LaTeX;

prog: assign EOF;

// funcCall: FUNCTION '(';

exprList: expr (',' expr)*;
// | matrixStart matrixRowCommaDelimited matrixEnd;

number: DIGIT* '.' DIGIT+ | DIGIT+;
id: LETTER (DIGIT | LETTER)* | '{' id '}';
namedConstant: '\\pi';

desc: (DIGIT | LETTER | '-' | ',')+;
subscript: '_{' desc '}' | '_' (DIGIT | LETTER);
varMod: '\\bar';
var: varMod '{' id '}' subscript? | id subscript?;
// stringLiteral: '"' .*? '"' | '\'' .*? '\'';

assign: var '=' expr;

// matrixStart: '\\begin{matrix}'; matrixEnd: '\\end{matrix}'; matrix: matrixStart matrixRow+
// matrixEnd;

// matrixRow: expr ('&' expr)* '\\\\'; matrixRowCommaDelimited: expr (',' '&' expr)* '\\\\';

lessThan: '<';
lessThanEqual: '\\le' 'q'? | '<=';
greaterThan: '>';
greaterThanEqual: '\\ge' 'q'? | '>=';

comparison:
	lessThan
	| lessThanEqual
	| greaterThan
	| greaterThanEqual;

// expr: exprGroup | number | var | constant | expr exprGroup | exprGroup expr | expr '^' expr |
// expr '^{' expr '}' | (number | constant) expr | expr ('*' | '\\ast' | '\\times' | '/' | '\\dot')
// expr | expr ('+' | '-') expr | expr comparison expr;

expr:
	unaryFunction expr
	| <assoc = right> expr '^' expr
	| expr BINARY_OPERATOR expr
	| ('\\sfrac' | '\\frac') expr expr
	| expr ('+' | '-') expr
	| expr comparison expr
	| setFunction '(' exprList ')'
	| var
	| assign
	| number
	| '{' expr '}'
	| '(' expr ')';

// unaryExpr: ; binaryExpr: <assoc = right> expr '^' expr | expr ('*' | '\\ast' | '\\times' | '/' |
// '\\dot') expr | ('\\sfrac' | '\\frac') expr expr | expr ('+' | '-') expr | expr comparison expr;
// setExpr: setFunction '(' exprList ')'; paramExpr: var | assign; constantExpr: number;

unaryFunction: '\\sqrt';
setFunction: 'max' | 'min';

LETTER: GREEK | [a-zA-Z];
DIGIT: [0-9];
WS: ('\\'? ' ' | [\t\r\n])+ -> skip;
// skip spaces, tabs, newlines
MISC_SKIP: ('\\left' | '\\right' '.'?) -> skip;
BINARY_OPERATOR: '*' | '\\ast' | '\\times' | '/' | '\\dot';

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
