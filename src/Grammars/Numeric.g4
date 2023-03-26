grammar Numeric;
import Common;

numericExpr:
	groupedNum													# GroupedNumExpr
	| unaryNumLeftRight											# UnaryNumExpr
	| unaryNumOpLeft numericExpr								# UnaryNumExpr
	| trigFunc arg = numericExpr								# TrigFuncExpr
	| baseTrigFunc EXP_OP exp = numericExpr arg = numericExpr	# TrigFuncExpr
	| binaryCmdName '{' numericExpr '}' '{' numericExpr '}'		# BinaryNumExpr
	| <assoc = right> numericExpr EXP_OP numericExpr			# BinaryNumExpr
	| numericExpr MUL_OP numericExpr							# BinaryNumExpr
	| numericExpr DIV_OP numericExpr							# BinaryNumExpr
	| numericExpr ADD_OP numericExpr							# BinaryNumExpr
	| numericExpr SUB_OP numericExpr							# BinaryNumExpr
	| var														# ParamNumExpr
	| NUM_CONST													# NumConstParamExpr
	| number													# ConstNumExpr;

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

unaryNumLeftRight: abs | ceiling | floor | round;

abs:
	'|' numericExpr '|'
	| '\\left|' numericExpr '\\right|'
	| '\\big|' numericExpr '\\big|'
	| '\\bigg|' numericExpr '\\bigg|'
	| '\\Bigg|' numericExpr '\\Bigg|';

ceiling:
	'\\lceil' numericExpr '\\rceil'
	| '\\left\\lceil' numericExpr '\\right\\rceil';
floor:
	'\\lfloor' numericExpr '\\rfloor'
	| '\\left\\lfloor' numericExpr '\\right\\rfloor';
round:
	'\\lfloor' numericExpr '\\rceil'
	| '\\left\\lfloor' numericExpr '\\right\\rceil';

unaryNumOpLeft: '-' | '\\sqrt' | logFunc;
negNumOp: '-';

logFunc: logType = '\\log' | logType = '\\ln' | logBaseFunc;
logBaseFunc:
	'\\log_' base += DIGIT
	| '\\log_{' base += DIGIT+ '}';

trigFunc:
	baseTrigFunc
	| '\\arcsin'
	| '\\arccos'
	| '\\arctan'
	| '\\sinh'
	| '\\cosh'
	| '\\tanh'
	| '\\cot'
	| '\\sec'
	| '\\csc';

baseTrigFunc: '\\sin' | '\\cos' | '\\tan';

// Binary Num Commands

binaryCmdName: divCmd;
divCmd: '\\' ('d' | 's' | 't')? 'frac';

// Binary Operations

ADD_OP: '+';
SUB_OP: '-';
MUL_OP: '*' | '\\ast' | '\\dot' | '\\times';
DIV_OP: '/' | '÷';
EXP_OP: '^';

number: DIGIT* '.' DIGIT+ | DIGIT+;

NUM_CONST: '\\pi';
