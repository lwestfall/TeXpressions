grammar Numeric;
import Common;

numericExpr:
	groupedNum												# GroupedNumExpr
	| unaryNumCmdName '{' numericExpr '}'					# UnaryNumExpr
	| unaryNumOpPre numericExpr								# UnaryNumExpr
	| binaryCmdName '{' numericExpr '}{' numericExpr '}'	# BinaryNumExpr
	| <assoc = right> numericExpr EXP_OP numericExpr		# BinaryNumExpr
	| numericExpr MUL_OP numericExpr						# BinaryNumExpr
	| numericExpr DIV_OP numericExpr						# BinaryNumExpr
	| numericExpr ADD_OP numericExpr						# BinaryNumExpr
	| numericExpr SUB_OP numericExpr						# BinaryNumExpr
	| var													# ParamNumExpr
	| NUMBER												# ConstNumExpr;

groupedNum:
	'(' numericExpr ')'
	| '\\left(' numericExpr '\\right)'
	| '\\bigl(' numericExpr '\\bigr)'
	| '\\Bigl(' numericExpr '\\Bigr)'
	| '\\biggl(' numericExpr '\\biggr)'
	| '\\Biggl(' numericExpr '\\Biggr)'
	| '[' numericExpr ']'
	| '\\left[' numericExpr '\\right]'
	| '\\bigl[' numericExpr '\\bigr]'
	| '\\Bigl[' numericExpr '\\Bigr]'
	| '\\bigg[' numericExpr '\\biggr]'
	| '\\Bigg[' numericExpr '\\Biggr]'
	| '{' numericExpr '}'
	| '\\{' numericExpr '\\}'
	| '\\left\\{' numericExpr '\\right\\}'
	| '\\bigl\\{' numericExpr '\\bigr\\}'
	| '\\Bigl\\{' numericExpr '\\Bigr\\}'
	| '\\bigg\\{' numericExpr '\\biggr\\}'
	| '\\Bigg\\{' numericExpr '\\Biggr\\}';

// Unary

unaryNumCmdName: '\\sqrt';
unaryNumOpPre: negNumOp;
negNumOp: '-';

// Binary Num Commands

binaryCmdName: divCmd;
divCmd: '\\' ('d' | 's' | 't')? 'frac';

// Binary Operations

ADD_OP: '+';
SUB_OP: '-';
MUL_OP: '*' | '\\ast' | '\\dot' | '\\times';
DIV_OP: '/' | '÷';
EXP_OP: '^';

NUMBER: DIGIT* '.' DIGIT+ | DIGIT+;

NUM_CONST: '\\pi';
