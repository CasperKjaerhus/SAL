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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="p4Parser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface Ip4Visitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.s"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitS([NotNull] p4Parser.SContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.importStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImportStmt([NotNull] p4Parser.ImportStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmt([NotNull] p4Parser.StmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.global"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGlobal([NotNull] p4Parser.GlobalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] p4Parser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] p4Parser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.returnExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnExpr([NotNull] p4Parser.ReturnExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.funcDcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncDcl([NotNull] p4Parser.FuncDclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParams([NotNull] p4Parser.ParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] p4Parser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.returnsStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnsStmt([NotNull] p4Parser.ReturnsStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] p4Parser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] p4Parser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctioncall([NotNull] p4Parser.FunctioncallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArguments([NotNull] p4Parser.ArgumentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.controlStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitControlStructure([NotNull] p4Parser.ControlStructureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.ifStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStmt([NotNull] p4Parser.IfStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.elseStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStmt([NotNull] p4Parser.ElseStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.loopStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopStructure([NotNull] p4Parser.LoopStructureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.forexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForexpr([NotNull] p4Parser.ForexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.whileexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileexpr([NotNull] p4Parser.WhileexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.foreachexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeachexpr([NotNull] p4Parser.ForeachexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.switchStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchStmt([NotNull] p4Parser.SwitchStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.switchBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchBody([NotNull] p4Parser.SwitchBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.switchItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchItem([NotNull] p4Parser.SwitchItemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] p4Parser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.condExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondExpr([NotNull] p4Parser.CondExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.logORexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogORexpr([NotNull] p4Parser.LogORexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.logANDexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogANDexpr([NotNull] p4Parser.LogANDexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.andExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpr([NotNull] p4Parser.AndExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.relExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelExpr([NotNull] p4Parser.RelExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.addExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpr([NotNull] p4Parser.AddExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.multExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultExpr([NotNull] p4Parser.MultExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExprList([NotNull] p4Parser.ExprListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.postExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostExpr([NotNull] p4Parser.PostExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.primExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimExpr([NotNull] p4Parser.PrimExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] p4Parser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostfix([NotNull] p4Parser.PostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.prefix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrefix([NotNull] p4Parser.PrefixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.valuetype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValuetype([NotNull] p4Parser.ValuetypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.returntype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturntype([NotNull] p4Parser.ReturntypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] p4Parser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] p4Parser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.assnOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssnOp([NotNull] p4Parser.AssnOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="p4Parser.modifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModifier([NotNull] p4Parser.ModifierContext context);
}
