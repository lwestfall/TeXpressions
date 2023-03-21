grammar Logic;
import Numeric;

logicExpr:
	groupedLogic					# GroupedLogicExpr
	| unaryLogicOpPre logicExpr		# UnaryLogicExpr
	| logicExpr AND_OP logicExpr	# BinaryLogicExpr
	| logicExpr OR_OP logicExpr		# BinaryLogicExpr
	| logicExpr EQ_OP logicExpr		# BinaryLogicExpr
	| numericExpr cmpOp numericExpr	# NumericCompareExpr
	| var							# ParamLogicExpr
	| LOGIC_CONST					# ConstLogicExpr;

groupedLogic:
	'(' logicExpr ')'
	| '\\left(' logicExpr '\\right)'
	| '\\bigl(' logicExpr '\\bigr)'
	| '\\Bigl(' logicExpr '\\Bigr)'
	| '\\biggl(' logicExpr '\\biggr)'
	| '\\Biggl(' logicExpr '\\Biggr)'
	| '[' logicExpr ']'
	| '\\left[' logicExpr '\\right]'
	| '\\bigl[' logicExpr '\\bigr]'
	| '\\Bigl[' logicExpr '\\Bigr]'
	| '\\bigg[' logicExpr '\\biggr]'
	| '\\Bigg[' logicExpr '\\Biggr]'
	| '{' logicExpr '}'
	| '\\left\\{' logicExpr '\\right\\}'
	| '\\bigl\\{' logicExpr '\\bigr\\}'
	| '\\Bigl\\{' logicExpr '\\Bigr\\}'
	| '\\bigg\\{' logicExpr '\\biggr\\}'
	| '\\Bigg\\{' logicExpr '\\Biggr\\}';

// Unary Logic

unaryLogicOpPre: negLogicalOp;

negLogicalOp: '\\neg' | '\\lnot' | '\\lsim' | '!';

// Binary Logic

cmpOp: '<=' | '>=' | '\\leq' | '\\geq' | '<' | '>' | EQ_OP;

AND_OP: '\\wedge' | '\\land' | '\\&' | '\\cdot';
OR_OP: '\\vee' | '\\lor' | '\\parallel';
EQ_OP:
	'='
	| '\\leftrightarrow'
	| '\\Leftrightarrow'
	| '\\neq'
	| '!=';

LOGIC_CONST: '\\top' | '\\bot';
