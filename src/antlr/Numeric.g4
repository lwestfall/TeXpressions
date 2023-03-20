grammar Numeric;
import Common;

numericExpr:
	'(' numericExpr ')'										# GroupNumExpr
	| unaryNumCmdName '{' numericExpr '}'					# UnaryNumExpr
	| unaryNumOpPre numericExpr								# UnaryNumExpr
	| binaryCmdName '{' numericExpr '}{' numericExpr '}'	# BinaryNumExpr
	| numericExpr binaryNumericOp numericExpr				# BinaryNumExpr
	| var													# ParamNumExpr
	| NUMBER												# ConstantExpr;

// Unary

unaryNumCmdName: '\\sqrt';
unaryNumOpPre: negNumOp;
negNumOp: '-';

// Binary Num Commands

binaryCmdName: divCmd;
divCmd: '\\' ('d' | 's' | 't')? 'frac';

// Binary Operations

binaryNumericOp: ADD_OP | SUB_OP | MUL_OP | DIV_OP | EXP_OP;

ADD_OP: '+';
SUB_OP: '-';
MUL_OP: '*' | '\\ast' | '\\dot' | '\\times';
DIV_OP: '/' | '÷';
EXP_OP: '^';

NUMBER: DIGIT* '.' DIGIT+ | DIGIT+;

NUM_CONST: '\\pi';
