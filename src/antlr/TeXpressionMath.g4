grammar TeXpressionMath;

inlineMath: ('$' expr '$' | '\\(' expr '\\)') EOF;

expr:
	binaryCmdName '{' l = expr '}{' r = expr '}'	# BinaryExpr
	| l = expr op = binaryOp r = expr				# BinaryExpr
	| assign										# ParamExpr
	| number										# ConstantExpr;

binaryOp: addOp | subOp | mulOp | divOp | expOp;

addOp: '+';
subOp: '-';
mulOp: '*' | '\\ast' | '*' | '\\dot' | '\\times';
divOp: '/' | '÷';
expOp: '^';

binaryCmdName: divCmd;
divCmd: '\\' ('d' | 's' | 't')? 'frac';

assign: var '=' expr;

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
