grammar TeXpressionMath;

program: inlineMath | expr EOF;

inlineMath: '$' expr '$' | '\\(' expr '\\)';

assign: var '=' expr;

expr:
	binaryCmd				# BinaryExpr
	| expr binaryOp expr	# BinaryExpr
	| number				# ConstantExpr;
bracedExpr: '{' expr '}';

binaryOp: '+' | '-' | '*' | '\\ast' | '*' | '\\dot' | '\\times';
binaryCmd: fracCmd bracedExpr bracedExpr;
binaryCmdName: fracCmd;
fracCmd: '\\' ('d' | 's' | 't') 'frac';

varMod: '\\bar';
var: varMod '{' id '}' subscript? | id subscript?;

desc: (DIGIT | LETTER | '-' | ',')+;
subscript: '_{' desc '}' | '_' (DIGIT | LETTER);

number: DIGIT* '.' DIGIT+ | DIGIT+;
id: LETTER (DIGIT | LETTER)* | '{' id '}';

LETTER: GREEK | [a-zA-Z];
DIGIT: [0-9];
WS: ('\\'? ' ' | [\t\r\n])+ -> skip;
// skip spaces, tabs, newlines
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
