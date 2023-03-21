grammar Logic;
import Numeric;

logicExpr:
	'(' logicExpr ')'				# GroupLogicExpr
	| unaryLogicOpPre logicExpr		# UnaryLogicExpr
	| logicExpr AND_OP logicExpr	# BinaryLogicExpr
	| logicExpr OR_OP logicExpr		# BinaryLogicExpr
	| logicExpr EQ_OP logicExpr		# BinaryLogicExpr
	| numericExpr cmpOp numericExpr	# NumericCompareExpr
	| var							# ParamLogicExpr
	| LOGIC_CONST					# ConstLogicExpr;

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
