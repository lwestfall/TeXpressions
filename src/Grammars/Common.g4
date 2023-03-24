grammar Common;

// Params / variables

varMod: '\\bar';
var: (varMod '{' id '}' | id) subscript?;

desc: (DIGIT | LETTER | '-' | ',')+;
subscript: '_{' desc '}' | '_' (DIGIT | LETTER);

// Basic

id: LETTER (DIGIT | LETTER)*;

LETTER: GREEK | [a-zA-Z];
DIGIT: [0-9];
WS: ('\\'? ' ' | [\t\r\n])+ -> skip;
// skip spaces, tabs, newlines
MISC_SKIP: ('\\left.' | '\\right.') -> skip;

NUM_CONST: '\\pi';

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
