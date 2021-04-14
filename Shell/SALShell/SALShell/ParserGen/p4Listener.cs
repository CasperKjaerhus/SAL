//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from p4.g4 by ANTLR 4.9.2

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
/// <see cref="p4Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface Ip4Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.s"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterS([NotNull] p4Parser.SContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.s"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitS([NotNull] p4Parser.SContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.importStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImportStmt([NotNull] p4Parser.ImportStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.importStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImportStmt([NotNull] p4Parser.ImportStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmt([NotNull] p4Parser.StmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmt([NotNull] p4Parser.StmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] p4Parser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] p4Parser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.returnExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnExpr([NotNull] p4Parser.ReturnExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.returnExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnExpr([NotNull] p4Parser.ReturnExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.funcDcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncDcl([NotNull] p4Parser.FuncDclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.funcDcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncDcl([NotNull] p4Parser.FuncDclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParams([NotNull] p4Parser.ParamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParams([NotNull] p4Parser.ParamsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam([NotNull] p4Parser.ParamContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam([NotNull] p4Parser.ParamContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.functionBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionBody([NotNull] p4Parser.FunctionBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.functionBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionBody([NotNull] p4Parser.FunctionBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.returnsStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnsStmt([NotNull] p4Parser.ReturnsStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.returnsStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnsStmt([NotNull] p4Parser.ReturnsStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] p4Parser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] p4Parser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] p4Parser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] p4Parser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctioncall([NotNull] p4Parser.FunctioncallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctioncall([NotNull] p4Parser.FunctioncallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArguments([NotNull] p4Parser.ArgumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArguments([NotNull] p4Parser.ArgumentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.controlStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterControlStructure([NotNull] p4Parser.ControlStructureContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.controlStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitControlStructure([NotNull] p4Parser.ControlStructureContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.ifStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStmt([NotNull] p4Parser.IfStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.ifStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStmt([NotNull] p4Parser.IfStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.elseStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseStmt([NotNull] p4Parser.ElseStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.elseStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseStmt([NotNull] p4Parser.ElseStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.loopStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoopStructure([NotNull] p4Parser.LoopStructureContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.loopStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoopStructure([NotNull] p4Parser.LoopStructureContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.forexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForexpr([NotNull] p4Parser.ForexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.forexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForexpr([NotNull] p4Parser.ForexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.whileexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileexpr([NotNull] p4Parser.WhileexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.whileexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileexpr([NotNull] p4Parser.WhileexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.foreachexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForeachexpr([NotNull] p4Parser.ForeachexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.foreachexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForeachexpr([NotNull] p4Parser.ForeachexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.switchStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSwitchStmt([NotNull] p4Parser.SwitchStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.switchStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSwitchStmt([NotNull] p4Parser.SwitchStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.switchBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSwitchBody([NotNull] p4Parser.SwitchBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.switchBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSwitchBody([NotNull] p4Parser.SwitchBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.switchItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSwitchItem([NotNull] p4Parser.SwitchItemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.switchItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSwitchItem([NotNull] p4Parser.SwitchItemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] p4Parser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] p4Parser.ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.condExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondExpr([NotNull] p4Parser.CondExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.condExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondExpr([NotNull] p4Parser.CondExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.logORexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogORexpr([NotNull] p4Parser.LogORexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.logORexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogORexpr([NotNull] p4Parser.LogORexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.logANDexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogANDexpr([NotNull] p4Parser.LogANDexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.logANDexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogANDexpr([NotNull] p4Parser.LogANDexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.andExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExpr([NotNull] p4Parser.AndExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.andExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExpr([NotNull] p4Parser.AndExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.relExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelExpr([NotNull] p4Parser.RelExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.relExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelExpr([NotNull] p4Parser.RelExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.addExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddExpr([NotNull] p4Parser.AddExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.addExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddExpr([NotNull] p4Parser.AddExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.multExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultExpr([NotNull] p4Parser.MultExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.multExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultExpr([NotNull] p4Parser.MultExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprList([NotNull] p4Parser.ExprListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprList([NotNull] p4Parser.ExprListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.postExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPostExpr([NotNull] p4Parser.PostExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.postExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPostExpr([NotNull] p4Parser.PostExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.primExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimExpr([NotNull] p4Parser.PrimExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.primExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimExpr([NotNull] p4Parser.PrimExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] p4Parser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] p4Parser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPostfix([NotNull] p4Parser.PostfixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPostfix([NotNull] p4Parser.PostfixContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.prefix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrefix([NotNull] p4Parser.PrefixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.prefix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrefix([NotNull] p4Parser.PrefixContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.valuetype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValuetype([NotNull] p4Parser.ValuetypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.valuetype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValuetype([NotNull] p4Parser.ValuetypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.returntype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturntype([NotNull] p4Parser.ReturntypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.returntype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturntype([NotNull] p4Parser.ReturntypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] p4Parser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] p4Parser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBool([NotNull] p4Parser.BoolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBool([NotNull] p4Parser.BoolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="p4Parser.assnOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssnOp([NotNull] p4Parser.AssnOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="p4Parser.assnOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssnOp([NotNull] p4Parser.AssnOpContext context);
}
