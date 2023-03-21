//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from src/antlr/TeXpression.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


#pragma warning disable 3021

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="TeXpressionParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface ITeXpressionVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.inline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInline([NotNull] TeXpressionParser.InlineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.topExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTopExpr([NotNull] TeXpressionParser.TopExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] TeXpressionParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryLogicExpr([NotNull] TeXpressionParser.UnaryLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParamLogicExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParamLogicExpr([NotNull] TeXpressionParser.ParamLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NumericCompareExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumericCompareExpr([NotNull] TeXpressionParser.NumericCompareExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>GroupedLogicExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupedLogicExpr([NotNull] TeXpressionParser.GroupedLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ConstLogicExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstLogicExpr([NotNull] TeXpressionParser.ConstLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryLogicExpr([NotNull] TeXpressionParser.BinaryLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.groupedLogic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupedLogic([NotNull] TeXpressionParser.GroupedLogicContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.unaryLogicOpPre"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryLogicOpPre([NotNull] TeXpressionParser.UnaryLogicOpPreContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.negLogicalOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNegLogicalOp([NotNull] TeXpressionParser.NegLogicalOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.cmpOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCmpOp([NotNull] TeXpressionParser.CmpOpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>GroupedNumExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.numericExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupedNumExpr([NotNull] TeXpressionParser.GroupedNumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParamNumExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.numericExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParamNumExpr([NotNull] TeXpressionParser.ParamNumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ConstNumExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.numericExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstNumExpr([NotNull] TeXpressionParser.ConstNumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryNumExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.numericExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryNumExpr([NotNull] TeXpressionParser.UnaryNumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryNumExpr</c>
	/// labeled alternative in <see cref="TeXpressionParser.numericExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryNumExpr([NotNull] TeXpressionParser.BinaryNumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.groupedNum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupedNum([NotNull] TeXpressionParser.GroupedNumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.unaryNumCmdName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryNumCmdName([NotNull] TeXpressionParser.UnaryNumCmdNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.unaryNumOpPre"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryNumOpPre([NotNull] TeXpressionParser.UnaryNumOpPreContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.negNumOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNegNumOp([NotNull] TeXpressionParser.NegNumOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.binaryCmdName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryCmdName([NotNull] TeXpressionParser.BinaryCmdNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.divCmd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivCmd([NotNull] TeXpressionParser.DivCmdContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.varMod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarMod([NotNull] TeXpressionParser.VarModContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar([NotNull] TeXpressionParser.VarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.desc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDesc([NotNull] TeXpressionParser.DescContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.subscript"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscript([NotNull] TeXpressionParser.SubscriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] TeXpressionParser.IdContext context);
}
