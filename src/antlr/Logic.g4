grammar Logic;
import Numeric;

logicExpr:
	'(' logicExpr ')'					# GroupLogicExpr
	| unaryLogicOpPre logicExpr			# UnaryLogicExpr
	| logicExpr BIN_LOGIC_OP logicExpr	# BinaryLogicExpr
	| numericExpr CMP_OP numericExpr	# BinaryLogicExpr
	| var								# BinaryParamExpr
	| LOGIC_CONST						# BinaryConstExpr;

// Unary Logic
unaryLogicOpPre: negLogicalOp;

negLogicalOp: '\\neg' | '\\lnot' | '\\lsim' | '!';

// Binary Logic

BIN_LOGIC_OP: EQ_OP | AND_OP | OR_OP;

CMP_OP: '<=' | '>=' | '\\leq' | '\\geq' | '<' | '>' | EQ_OP;

AND_OP: '\\wedge' | '\\land' | '\\&' | '\\cdot';
OR_OP: '\\vee' | '\\lor' | '\\parallel';
EQ_OP:
	'='
	| '\\leftrightarrow'
	| '\\Leftrightarrow'
	| '\\neq'
	| '!' EQ_OP;

LOGIC_CONST: '\\top' | '\\BOT';
