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

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="TeXpressionMathParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface ITeXpressionMathVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.inlineMath"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInlineMath([NotNull] TeXpressionMathParser.InlineMathContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParamExpr</c>
	/// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParamExpr([NotNull] TeXpressionMathParser.ParamExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryExpr</c>
	/// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryExpr([NotNull] TeXpressionMathParser.BinaryExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ConstantExpr</c>
	/// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantExpr([NotNull] TeXpressionMathParser.ConstantExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.binaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryOp([NotNull] TeXpressionMathParser.BinaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddOp([NotNull] TeXpressionMathParser.AddOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.subOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubOp([NotNull] TeXpressionMathParser.SubOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.mulOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulOp([NotNull] TeXpressionMathParser.MulOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.divOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivOp([NotNull] TeXpressionMathParser.DivOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.expOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpOp([NotNull] TeXpressionMathParser.ExpOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.binaryCmdName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryCmdName([NotNull] TeXpressionMathParser.BinaryCmdNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.divCmd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivCmd([NotNull] TeXpressionMathParser.DivCmdContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.assign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssign([NotNull] TeXpressionMathParser.AssignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.varMod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarMod([NotNull] TeXpressionMathParser.VarModContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar([NotNull] TeXpressionMathParser.VarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.desc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDesc([NotNull] TeXpressionMathParser.DescContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.subscript"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscript([NotNull] TeXpressionMathParser.SubscriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] TeXpressionMathParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TeXpressionMathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] TeXpressionMathParser.IdContext context);
}
