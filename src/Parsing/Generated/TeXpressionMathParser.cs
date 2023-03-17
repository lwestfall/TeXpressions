//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from src/antlr/TeXpressionMath.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public partial class TeXpressionMathParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, LETTER=27, DIGIT=28, WS=29, MISC_SKIP=30;
	public const int
		RULE_inlineMath = 0, RULE_topExpr = 1, RULE_expr = 2, RULE_binaryOp = 3, 
		RULE_addOp1 = 4, RULE_subOp = 5, RULE_mulOp = 6, RULE_divOp = 7, RULE_expOp = 8, 
		RULE_binaryCmdName = 9, RULE_divCmd = 10, RULE_assign = 11, RULE_varMod = 12, 
		RULE_var = 13, RULE_desc = 14, RULE_subscript = 15, RULE_number = 16, 
		RULE_id = 17;
	public static readonly string[] ruleNames = {
		"inlineMath", "topExpr", "expr", "binaryOp", "addOp1", "subOp", "mulOp", 
		"divOp", "expOp", "binaryCmdName", "divCmd", "assign", "varMod", "var", 
		"desc", "subscript", "number", "id"
	};

	private static readonly string[] _LiteralNames = {
		null, "'$'", "'\\('", "'\\)'", "'{'", "'}{'", "'}'", "'+'", "'-'", "'*'", 
		"'\\ast'", "'\\dot'", "'\\times'", "'/'", "'\\u00F7'", "'^'", "'\\'", 
		"'d'", "'s'", "'t'", "'frac'", "'='", "'\\bar'", "','", "'_{'", "'_'", 
		"'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "LETTER", "DIGIT", "WS", "MISC_SKIP"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "TeXpressionMath.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static TeXpressionMathParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public TeXpressionMathParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public TeXpressionMathParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class InlineMathContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(TeXpressionMathParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TopExprContext topExpr() {
			return GetRuleContext<TopExprContext>(0);
		}
		public InlineMathContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_inlineMath; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInlineMath(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public InlineMathContext inlineMath() {
		InlineMathContext _localctx = new InlineMathContext(Context, State);
		EnterRule(_localctx, 0, RULE_inlineMath);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__0:
				{
				State = 36;
				Match(T__0);
				State = 37;
				topExpr();
				State = 38;
				Match(T__0);
				}
				break;
			case T__1:
				{
				State = 40;
				Match(T__1);
				State = 41;
				topExpr();
				State = 42;
				Match(T__2);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			State = 46;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TopExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public AssignContext assign() {
			return GetRuleContext<AssignContext>(0);
		}
		public TopExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_topExpr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTopExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TopExprContext topExpr() {
		TopExprContext _localctx = new TopExprContext(Context, State);
		EnterRule(_localctx, 2, RULE_topExpr);
		try {
			State = 50;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 48;
				expr(0);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 49;
				assign();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParamExprContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public AssignContext assign() {
			return GetRuleContext<AssignContext>(0);
		}
		public ParamExprContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParamExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class BinaryExprContext : ExprContext {
		public ExprContext l;
		public ExprContext r;
		public BinaryOpContext op;
		[System.Diagnostics.DebuggerNonUserCode] public BinaryCmdNameContext binaryCmdName() {
			return GetRuleContext<BinaryCmdNameContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public BinaryOpContext binaryOp() {
			return GetRuleContext<BinaryOpContext>(0);
		}
		public BinaryExprContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBinaryExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ConstantExprContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		public ConstantExprContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConstantExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 4;
		EnterRecursionRule(_localctx, 4, RULE_expr, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 62;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__15:
				{
				_localctx = new BinaryExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 53;
				binaryCmdName();
				State = 54;
				Match(T__3);
				State = 55;
				((BinaryExprContext)_localctx).l = expr(0);
				State = 56;
				Match(T__4);
				State = 57;
				((BinaryExprContext)_localctx).r = expr(0);
				State = 58;
				Match(T__5);
				}
				break;
			case T__3:
			case T__21:
			case LETTER:
				{
				_localctx = new ParamExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 60;
				assign();
				}
				break;
			case T__25:
			case DIGIT:
				{
				_localctx = new ConstantExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 61;
				number();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 70;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new BinaryExprContext(new ExprContext(_parentctx, _parentState));
					((BinaryExprContext)_localctx).l = _prevctx;
					PushNewRecursionContext(_localctx, _startState, RULE_expr);
					State = 64;
					if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
					State = 65;
					((BinaryExprContext)_localctx).op = binaryOp();
					State = 66;
					((BinaryExprContext)_localctx).r = expr(4);
					}
					} 
				}
				State = 72;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class BinaryOpContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public AddOp1Context addOp1() {
			return GetRuleContext<AddOp1Context>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public SubOpContext subOp() {
			return GetRuleContext<SubOpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MulOpContext mulOp() {
			return GetRuleContext<MulOpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public DivOpContext divOp() {
			return GetRuleContext<DivOpContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpOpContext expOp() {
			return GetRuleContext<ExpOpContext>(0);
		}
		public BinaryOpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_binaryOp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBinaryOp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BinaryOpContext binaryOp() {
		BinaryOpContext _localctx = new BinaryOpContext(Context, State);
		EnterRule(_localctx, 6, RULE_binaryOp);
		try {
			State = 78;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__6:
				EnterOuterAlt(_localctx, 1);
				{
				State = 73;
				addOp1();
				}
				break;
			case T__7:
				EnterOuterAlt(_localctx, 2);
				{
				State = 74;
				subOp();
				}
				break;
			case T__8:
			case T__9:
			case T__10:
			case T__11:
				EnterOuterAlt(_localctx, 3);
				{
				State = 75;
				mulOp();
				}
				break;
			case T__12:
			case T__13:
				EnterOuterAlt(_localctx, 4);
				{
				State = 76;
				divOp();
				}
				break;
			case T__14:
				EnterOuterAlt(_localctx, 5);
				{
				State = 77;
				expOp();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddOp1Context : ParserRuleContext {
		public AddOp1Context(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addOp1; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddOp1(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AddOp1Context addOp1() {
		AddOp1Context _localctx = new AddOp1Context(Context, State);
		EnterRule(_localctx, 8, RULE_addOp1);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 80;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SubOpContext : ParserRuleContext {
		public SubOpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_subOp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSubOp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SubOpContext subOp() {
		SubOpContext _localctx = new SubOpContext(Context, State);
		EnterRule(_localctx, 10, RULE_subOp);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			Match(T__7);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MulOpContext : ParserRuleContext {
		public MulOpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_mulOp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMulOp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MulOpContext mulOp() {
		MulOpContext _localctx = new MulOpContext(Context, State);
		EnterRule(_localctx, 12, RULE_mulOp);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 84;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 7680L) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DivOpContext : ParserRuleContext {
		public DivOpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_divOp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDivOp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DivOpContext divOp() {
		DivOpContext _localctx = new DivOpContext(Context, State);
		EnterRule(_localctx, 14, RULE_divOp);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 86;
			_la = TokenStream.LA(1);
			if ( !(_la==T__12 || _la==T__13) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpOpContext : ParserRuleContext {
		public ExpOpContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expOp; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpOp(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpOpContext expOp() {
		ExpOpContext _localctx = new ExpOpContext(Context, State);
		EnterRule(_localctx, 16, RULE_expOp);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 88;
			Match(T__14);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BinaryCmdNameContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public DivCmdContext divCmd() {
			return GetRuleContext<DivCmdContext>(0);
		}
		public BinaryCmdNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_binaryCmdName; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBinaryCmdName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BinaryCmdNameContext binaryCmdName() {
		BinaryCmdNameContext _localctx = new BinaryCmdNameContext(Context, State);
		EnterRule(_localctx, 18, RULE_binaryCmdName);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 90;
			divCmd();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DivCmdContext : ParserRuleContext {
		public DivCmdContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_divCmd; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDivCmd(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DivCmdContext divCmd() {
		DivCmdContext _localctx = new DivCmdContext(Context, State);
		EnterRule(_localctx, 20, RULE_divCmd);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 92;
			Match(T__15);
			State = 94;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 917504L) != 0)) {
				{
				State = 93;
				_la = TokenStream.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 917504L) != 0)) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
			}

			State = 96;
			Match(T__19);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VarContext var() {
			return GetRuleContext<VarContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public AssignContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assign; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssign(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AssignContext assign() {
		AssignContext _localctx = new AssignContext(Context, State);
		EnterRule(_localctx, 22, RULE_assign);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 98;
			var();
			State = 99;
			Match(T__20);
			State = 100;
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarModContext : ParserRuleContext {
		public VarModContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_varMod; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarMod(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarModContext varMod() {
		VarModContext _localctx = new VarModContext(Context, State);
		EnterRule(_localctx, 24, RULE_varMod);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 102;
			Match(T__21);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VarModContext varMod() {
			return GetRuleContext<VarModContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public IdContext id() {
			return GetRuleContext<IdContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public SubscriptContext subscript() {
			return GetRuleContext<SubscriptContext>(0);
		}
		public VarContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_var; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVar(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarContext var() {
		VarContext _localctx = new VarContext(Context, State);
		EnterRule(_localctx, 26, RULE_var);
		int _la;
		try {
			State = 115;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__21:
				EnterOuterAlt(_localctx, 1);
				{
				State = 104;
				varMod();
				State = 105;
				Match(T__3);
				State = 106;
				id();
				State = 107;
				Match(T__5);
				State = 109;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==T__23 || _la==T__24) {
					{
					State = 108;
					subscript();
					}
				}

				}
				break;
			case T__3:
			case LETTER:
				EnterOuterAlt(_localctx, 2);
				{
				State = 111;
				id();
				State = 113;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==T__23 || _la==T__24) {
					{
					State = 112;
					subscript();
					}
				}

				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DescContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIGIT() { return GetTokens(TeXpressionMathParser.DIGIT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT(int i) {
			return GetToken(TeXpressionMathParser.DIGIT, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LETTER() { return GetTokens(TeXpressionMathParser.LETTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER(int i) {
			return GetToken(TeXpressionMathParser.LETTER, i);
		}
		public DescContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_desc; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDesc(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DescContext desc() {
		DescContext _localctx = new DescContext(Context, State);
		EnterRule(_localctx, 28, RULE_desc);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 118;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 117;
				_la = TokenStream.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 411042048L) != 0)) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
				}
				State = 120;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 411042048L) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SubscriptContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public DescContext desc() {
			return GetRuleContext<DescContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT() { return GetToken(TeXpressionMathParser.DIGIT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER() { return GetToken(TeXpressionMathParser.LETTER, 0); }
		public SubscriptContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_subscript; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSubscript(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SubscriptContext subscript() {
		SubscriptContext _localctx = new SubscriptContext(Context, State);
		EnterRule(_localctx, 30, RULE_subscript);
		int _la;
		try {
			State = 128;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__23:
				EnterOuterAlt(_localctx, 1);
				{
				State = 122;
				Match(T__23);
				State = 123;
				desc();
				State = 124;
				Match(T__5);
				}
				break;
			case T__24:
				EnterOuterAlt(_localctx, 2);
				{
				State = 126;
				Match(T__24);
				State = 127;
				_la = TokenStream.LA(1);
				if ( !(_la==LETTER || _la==DIGIT) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NumberContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIGIT() { return GetTokens(TeXpressionMathParser.DIGIT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT(int i) {
			return GetToken(TeXpressionMathParser.DIGIT, i);
		}
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumber(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(Context, State);
		EnterRule(_localctx, 32, RULE_number);
		int _la;
		try {
			int _alt;
			State = 147;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,14,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 133;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==DIGIT) {
					{
					{
					State = 130;
					Match(DIGIT);
					}
					}
					State = 135;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 136;
				Match(T__25);
				State = 138;
				ErrorHandler.Sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						State = 137;
						Match(DIGIT);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					State = 140;
					ErrorHandler.Sync(this);
					_alt = Interpreter.AdaptivePredict(TokenStream,12,Context);
				} while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 143;
				ErrorHandler.Sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						State = 142;
						Match(DIGIT);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					State = 145;
					ErrorHandler.Sync(this);
					_alt = Interpreter.AdaptivePredict(TokenStream,13,Context);
				} while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class IdContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LETTER() { return GetTokens(TeXpressionMathParser.LETTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER(int i) {
			return GetToken(TeXpressionMathParser.LETTER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIGIT() { return GetTokens(TeXpressionMathParser.DIGIT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT(int i) {
			return GetToken(TeXpressionMathParser.DIGIT, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public IdContext id() {
			return GetRuleContext<IdContext>(0);
		}
		public IdContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_id; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ITeXpressionMathVisitor<TResult> typedVisitor = visitor as ITeXpressionMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitId(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public IdContext id() {
		IdContext _localctx = new IdContext(Context, State);
		EnterRule(_localctx, 34, RULE_id);
		int _la;
		try {
			State = 160;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case LETTER:
				EnterOuterAlt(_localctx, 1);
				{
				State = 149;
				Match(LETTER);
				State = 153;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==LETTER || _la==DIGIT) {
					{
					{
					State = 150;
					_la = TokenStream.LA(1);
					if ( !(_la==LETTER || _la==DIGIT) ) {
					ErrorHandler.RecoverInline(this);
					}
					else {
						ErrorHandler.ReportMatch(this);
					    Consume();
					}
					}
					}
					State = 155;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				break;
			case T__3:
				EnterOuterAlt(_localctx, 2);
				{
				State = 156;
				Match(T__3);
				State = 157;
				id();
				State = 158;
				Match(T__5);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 3);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,30,163,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,7,14,
		2,15,7,15,2,16,7,16,2,17,7,17,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,3,0,45,8,
		0,1,0,1,0,1,1,1,1,3,1,51,8,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,3,
		2,63,8,2,1,2,1,2,1,2,1,2,5,2,69,8,2,10,2,12,2,72,9,2,1,3,1,3,1,3,1,3,1,
		3,3,3,79,8,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,
		3,10,95,8,10,1,10,1,10,1,11,1,11,1,11,1,11,1,12,1,12,1,13,1,13,1,13,1,
		13,1,13,3,13,110,8,13,1,13,1,13,3,13,114,8,13,3,13,116,8,13,1,14,4,14,
		119,8,14,11,14,12,14,120,1,15,1,15,1,15,1,15,1,15,1,15,3,15,129,8,15,1,
		16,5,16,132,8,16,10,16,12,16,135,9,16,1,16,1,16,4,16,139,8,16,11,16,12,
		16,140,1,16,4,16,144,8,16,11,16,12,16,145,3,16,148,8,16,1,17,1,17,5,17,
		152,8,17,10,17,12,17,155,9,17,1,17,1,17,1,17,1,17,3,17,161,8,17,1,17,0,
		1,4,18,0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,0,5,1,0,9,12,1,
		0,13,14,1,0,17,19,3,0,8,8,23,23,27,28,1,0,27,28,165,0,44,1,0,0,0,2,50,
		1,0,0,0,4,62,1,0,0,0,6,78,1,0,0,0,8,80,1,0,0,0,10,82,1,0,0,0,12,84,1,0,
		0,0,14,86,1,0,0,0,16,88,1,0,0,0,18,90,1,0,0,0,20,92,1,0,0,0,22,98,1,0,
		0,0,24,102,1,0,0,0,26,115,1,0,0,0,28,118,1,0,0,0,30,128,1,0,0,0,32,147,
		1,0,0,0,34,160,1,0,0,0,36,37,5,1,0,0,37,38,3,2,1,0,38,39,5,1,0,0,39,45,
		1,0,0,0,40,41,5,2,0,0,41,42,3,2,1,0,42,43,5,3,0,0,43,45,1,0,0,0,44,36,
		1,0,0,0,44,40,1,0,0,0,45,46,1,0,0,0,46,47,5,0,0,1,47,1,1,0,0,0,48,51,3,
		4,2,0,49,51,3,22,11,0,50,48,1,0,0,0,50,49,1,0,0,0,51,3,1,0,0,0,52,53,6,
		2,-1,0,53,54,3,18,9,0,54,55,5,4,0,0,55,56,3,4,2,0,56,57,5,5,0,0,57,58,
		3,4,2,0,58,59,5,6,0,0,59,63,1,0,0,0,60,63,3,22,11,0,61,63,3,32,16,0,62,
		52,1,0,0,0,62,60,1,0,0,0,62,61,1,0,0,0,63,70,1,0,0,0,64,65,10,3,0,0,65,
		66,3,6,3,0,66,67,3,4,2,4,67,69,1,0,0,0,68,64,1,0,0,0,69,72,1,0,0,0,70,
		68,1,0,0,0,70,71,1,0,0,0,71,5,1,0,0,0,72,70,1,0,0,0,73,79,3,8,4,0,74,79,
		3,10,5,0,75,79,3,12,6,0,76,79,3,14,7,0,77,79,3,16,8,0,78,73,1,0,0,0,78,
		74,1,0,0,0,78,75,1,0,0,0,78,76,1,0,0,0,78,77,1,0,0,0,79,7,1,0,0,0,80,81,
		5,7,0,0,81,9,1,0,0,0,82,83,5,8,0,0,83,11,1,0,0,0,84,85,7,0,0,0,85,13,1,
		0,0,0,86,87,7,1,0,0,87,15,1,0,0,0,88,89,5,15,0,0,89,17,1,0,0,0,90,91,3,
		20,10,0,91,19,1,0,0,0,92,94,5,16,0,0,93,95,7,2,0,0,94,93,1,0,0,0,94,95,
		1,0,0,0,95,96,1,0,0,0,96,97,5,20,0,0,97,21,1,0,0,0,98,99,3,26,13,0,99,
		100,5,21,0,0,100,101,3,4,2,0,101,23,1,0,0,0,102,103,5,22,0,0,103,25,1,
		0,0,0,104,105,3,24,12,0,105,106,5,4,0,0,106,107,3,34,17,0,107,109,5,6,
		0,0,108,110,3,30,15,0,109,108,1,0,0,0,109,110,1,0,0,0,110,116,1,0,0,0,
		111,113,3,34,17,0,112,114,3,30,15,0,113,112,1,0,0,0,113,114,1,0,0,0,114,
		116,1,0,0,0,115,104,1,0,0,0,115,111,1,0,0,0,116,27,1,0,0,0,117,119,7,3,
		0,0,118,117,1,0,0,0,119,120,1,0,0,0,120,118,1,0,0,0,120,121,1,0,0,0,121,
		29,1,0,0,0,122,123,5,24,0,0,123,124,3,28,14,0,124,125,5,6,0,0,125,129,
		1,0,0,0,126,127,5,25,0,0,127,129,7,4,0,0,128,122,1,0,0,0,128,126,1,0,0,
		0,129,31,1,0,0,0,130,132,5,28,0,0,131,130,1,0,0,0,132,135,1,0,0,0,133,
		131,1,0,0,0,133,134,1,0,0,0,134,136,1,0,0,0,135,133,1,0,0,0,136,138,5,
		26,0,0,137,139,5,28,0,0,138,137,1,0,0,0,139,140,1,0,0,0,140,138,1,0,0,
		0,140,141,1,0,0,0,141,148,1,0,0,0,142,144,5,28,0,0,143,142,1,0,0,0,144,
		145,1,0,0,0,145,143,1,0,0,0,145,146,1,0,0,0,146,148,1,0,0,0,147,133,1,
		0,0,0,147,143,1,0,0,0,148,33,1,0,0,0,149,153,5,27,0,0,150,152,7,4,0,0,
		151,150,1,0,0,0,152,155,1,0,0,0,153,151,1,0,0,0,153,154,1,0,0,0,154,161,
		1,0,0,0,155,153,1,0,0,0,156,157,5,4,0,0,157,158,3,34,17,0,158,159,5,6,
		0,0,159,161,1,0,0,0,160,149,1,0,0,0,160,156,1,0,0,0,161,35,1,0,0,0,17,
		44,50,62,70,78,94,109,113,115,120,128,133,140,145,147,153,160
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
