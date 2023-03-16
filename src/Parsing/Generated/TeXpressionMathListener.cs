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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="TeXpressionMathParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface ITeXpressionMathListener : IParseTreeListener
{
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.program"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterProgram([NotNull] TeXpressionMathParser.ProgramContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.program"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitProgram([NotNull] TeXpressionMathParser.ProgramContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.inlineMath"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterInlineMath([NotNull] TeXpressionMathParser.InlineMathContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.inlineMath"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitInlineMath([NotNull] TeXpressionMathParser.InlineMathContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.assign"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterAssign([NotNull] TeXpressionMathParser.AssignContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.assign"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitAssign([NotNull] TeXpressionMathParser.AssignContext context);
    /// <summary>
    /// Enter a parse tree produced by the <c>BinaryExpr</c>
    /// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBinaryExpr([NotNull] TeXpressionMathParser.BinaryExprContext context);
    /// <summary>
    /// Exit a parse tree produced by the <c>BinaryExpr</c>
    /// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBinaryExpr([NotNull] TeXpressionMathParser.BinaryExprContext context);
    /// <summary>
    /// Enter a parse tree produced by the <c>ConstantExpr</c>
    /// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterConstantExpr([NotNull] TeXpressionMathParser.ConstantExprContext context);
    /// <summary>
    /// Exit a parse tree produced by the <c>ConstantExpr</c>
    /// labeled alternative in <see cref="TeXpressionMathParser.expr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitConstantExpr([NotNull] TeXpressionMathParser.ConstantExprContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.bracedExpr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBracedExpr([NotNull] TeXpressionMathParser.BracedExprContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.bracedExpr"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBracedExpr([NotNull] TeXpressionMathParser.BracedExprContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.binaryOp"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBinaryOp([NotNull] TeXpressionMathParser.BinaryOpContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.binaryOp"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBinaryOp([NotNull] TeXpressionMathParser.BinaryOpContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.binaryCmd"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBinaryCmd([NotNull] TeXpressionMathParser.BinaryCmdContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.binaryCmd"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBinaryCmd([NotNull] TeXpressionMathParser.BinaryCmdContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.binaryCmdName"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBinaryCmdName([NotNull] TeXpressionMathParser.BinaryCmdNameContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.binaryCmdName"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBinaryCmdName([NotNull] TeXpressionMathParser.BinaryCmdNameContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.fracCmd"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterFracCmd([NotNull] TeXpressionMathParser.FracCmdContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.fracCmd"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitFracCmd([NotNull] TeXpressionMathParser.FracCmdContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.varMod"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterVarMod([NotNull] TeXpressionMathParser.VarModContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.varMod"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitVarMod([NotNull] TeXpressionMathParser.VarModContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.var"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterVar([NotNull] TeXpressionMathParser.VarContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.var"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitVar([NotNull] TeXpressionMathParser.VarContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.desc"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterDesc([NotNull] TeXpressionMathParser.DescContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.desc"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitDesc([NotNull] TeXpressionMathParser.DescContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.subscript"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterSubscript([NotNull] TeXpressionMathParser.SubscriptContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.subscript"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitSubscript([NotNull] TeXpressionMathParser.SubscriptContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.number"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterNumber([NotNull] TeXpressionMathParser.NumberContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.number"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitNumber([NotNull] TeXpressionMathParser.NumberContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="TeXpressionMathParser.id"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterId([NotNull] TeXpressionMathParser.IdContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="TeXpressionMathParser.id"/>.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitId([NotNull] TeXpressionMathParser.IdContext context);
}
