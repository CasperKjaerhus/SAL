using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using SALShell.Compiler.Parser.Nodes;
using SALShell.Compiler.ParserGen;

namespace SALShell.Compiler.Parser
{
    public class ConcreteP4Visitor : p4BaseVisitor<ASTNode>
    {
        public override ASTNode VisitS([NotNull] p4Parser.SContext context)
        {
            StatementAstNode Root = null;

            if(context.importStmt() != null)
            {
                foreach (IParseTree importstmt in context.importStmt())
                {
                    if (Root == null)
                        Root = new StatementAstNode(Visit(importstmt), null);
                    else
                        Root.Push(new StatementAstNode(Visit(importstmt), null));
                }
            }

            if(context.funcDcl() != null)
            {
                foreach (IParseTree funcdcl in context.funcDcl())
                {
                    if (Root == null)
                        Root = new StatementAstNode(Visit(funcdcl), null);
                    else
                        Root.Push(new StatementAstNode(Visit(funcdcl), null));
                }
            }

            if(context.stmt() != null)
            {
                foreach(IParseTree stmt in context.stmt())
                {
                    if (Root == null)
                        Root = new StatementAstNode(Visit(stmt), null);
                    else
                        Root.Push(new StatementAstNode(Visit(stmt), null));
                }
            }

            return Root;
        }
        public override ASTNode VisitImportStmt([NotNull] p4Parser.ImportStmtContext context)
        {
            return new ImportStatementAstNode(context.Id().Symbol);
        }
        public override ASTNode VisitLoopStructure([NotNull] p4Parser.LoopStructureContext context)
        {
            if(context.forexpr() != null)
            {
                return Visit(context.forexpr());
            }
            if(context.foreachexpr() != null)
            {
                return Visit(context.foreachexpr());
            }
            if(context.whileexpr() != null)
            {
                return Visit(context.whileexpr());
            }

            return base.VisitLoopStructure(context);
        }
        public override ASTNode VisitForexpr([NotNull] p4Parser.ForexprContext context)
        {
            ASTNode Id = new IdAstNode(context.Id().Symbol, SALTypeEnum.number);
            if(context.Step() != null)
            {
                return new ForAstNode(Id, Visit(context.expr()[0]), Visit(context.expr()[1]), Visit(context.expr()[2]), Visit(context.block()), context.For().Symbol);
            }
            else
            {
                return new ForAstNode(Id, Visit(context.expr()[0]), Visit(context.expr()[1]), null, Visit(context.block()), context.For().Symbol);
            }
        }
        public override ASTNode VisitFuncDcl([NotNull] p4Parser.FuncDclContext context)
        {
            ASTNode returntype = Visit(context.returnsStmt());
            ASTNode functionId = new IdAstNode(context.Id().Symbol, SALType.Types[returntype.Token.Text]);
            return new FunctionDeclarationAstNode(functionId, Visit(context.@params()), Visit(context.block()), context.Function().Symbol);
        }

        public override ASTNode VisitFunctioncall([NotNull] p4Parser.FunctioncallContext context)
        {
            ASTNode functionId = new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined);
            if(context.arguments() != null)
            {
                return new FunctioncallAstNode(functionId, Visit(context?.arguments()), null);
            }
            else
            {
                return new FunctioncallAstNode(functionId, new ArgumentsAstNode(new ASTNode[]{}, null), null);
            }
            
        }

        public override ASTNode VisitReturnExpr([NotNull] p4Parser.ReturnExprContext context)
        {
            return new ReturnAstNode(Visit(context.expr()), context.Return().Symbol);
        }


        public override ASTNode VisitParams([NotNull] p4Parser.ParamsContext context)
        {
            List<ASTNode> parameters = new List<ASTNode>();
            foreach(IParseTree param in context.param())
            {
                parameters.Add(Visit(param));
            }
            return new ParameterListAstNode(parameters.ToArray(), null);
        }

        public override ASTNode VisitParam([NotNull] p4Parser.ParamContext context)
        {
            return new IdAstNode(context.Id().Symbol, SALType.Types[Visit(context.valuetype()).Token.Text]);
        }

        public override ASTNode VisitReturnsStmt([NotNull] p4Parser.ReturnsStmtContext context)
        {
            return Visit(context.returntype());
        }

        public override ASTNode VisitReturntype([NotNull] p4Parser.ReturntypeContext context)
        {
            if(context.VOID() != null)
            {
                return new TypeAstNode(context.VOID().Symbol);
            }
            else
            {
                return Visit(context.valuetype());
            }
        }

        public override ASTNode VisitForeachexpr([NotNull] p4Parser.ForeachexprContext context)
        {
            ASTNode itemId = new IdAstNode(context.Id()[0].Symbol, SALTypeEnum.undefined);
            ASTNode collectId = new IdAstNode(context.Id()[1].Symbol, SALTypeEnum.undefined);


            return new ForeachAstNode(itemId, collectId, Visit(context.block()), context.Foreach().Symbol);
        }

        public override ASTNode VisitWhileexpr([NotNull] p4Parser.WhileexprContext context)
        {
            return new WhileAstNode(Visit(context.expr()), Visit(context.block()), context.While().Symbol);
        }

        public override ASTNode VisitStmt([NotNull] p4Parser.StmtContext context)
        {
            if (context.assignment() != null)
            {
                return Visit(context.assignment());
            }
            else if (context.declaration() != null)
            {
                return Visit(context.declaration());
            }
            else if (context.postfix() != null)
            {
                return Visit(context.postfix());
            }
            else if (context.prefix() != null)
            {
                return Visit(context.prefix());
            }
            else if(context.functioncall() != null)
            {
                return Visit(context.functioncall());
            }
            else if (context.controlStructure() != null)
            {
                return Visit(context.controlStructure());
            }
            else if(context.loopStructure() != null)
            {
                return Visit(context.loopStructure());
            }
            else if(context.returnExpr() != null)
            {
                return Visit(context.returnExpr());
            }
            return base.VisitStmt(context);
        }

        public override ASTNode VisitControlStructure([NotNull] p4Parser.ControlStructureContext context)
        {
            if(context.ifStmt() != null)
            {
                return Visit(context.ifStmt());

            }
            else if(context.switchStmt() != null)
            {
                return Visit(context.switchStmt());
            }

            return base.VisitControlStructure(context);
        }
        public override ASTNode VisitIfStmt([NotNull] p4Parser.IfStmtContext context)
        {
            if(context.elseStmt() != null)
            {
                return new IfStructureAstNode(Visit(context.expr()), Visit(context.block()), Visit(context.elseStmt()), context.If().Symbol);
            }
            else
            {
                return new IfStructureAstNode(Visit(context.expr()), Visit(context.block()), null, context.If().Symbol);
            }
            
        }

        public override ASTNode VisitElseStmt([NotNull] p4Parser.ElseStmtContext context)
        {
            if(context.block() != null)
            {
                return Visit(context.block());
            }
            else if(context.ifStmt() != null)
            {
                return Visit(context.ifStmt());
            }

            throw new Exception("VisitElseStmt Exception");
        }

        public override ASTNode VisitSwitchStmt([NotNull] p4Parser.SwitchStmtContext context)
        {
            
            return new SwitchStructureAstNode(new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined), Visit(context.switchBody()), context.Switch().Symbol);
        }

        public override ASTNode VisitSwitchBody([NotNull] p4Parser.SwitchBodyContext context)
        {
            List<ASTNode> switchitems = new List<ASTNode>();
            foreach(IParseTree switchitem in context.switchItem())
            {
                switchitems.Add(Visit(switchitem));
            }

            return new SwitchBodyAstNode(switchitems.ToArray(), context.Begin().Symbol);
        }

        public override ASTNode VisitSwitchItem([NotNull] p4Parser.SwitchItemContext context)
        {
            if (context.block() != null && context.Break() != null)
            {
                return new SwitchItemAstNode(Visit(context.expr()), Visit(context.block()), true, context.CaseKeyword().Symbol);
            }
            else if (context.block() == null && context.Break() != null)
            {
                return new SwitchItemAstNode(Visit(context.expr()), null, true, context.CaseKeyword().Symbol);
            }
            else if(context.block() == null && context.Break() == null)
            {
                return new SwitchItemAstNode(Visit(context.expr()), null, false, context.CaseKeyword().Symbol);
            }
            else if (context.block() != null && context.Break() == null)
            {
                return new SwitchItemAstNode(Visit(context.expr()), Visit(context.block()), false, context.CaseKeyword().Symbol);
            }
            throw new Exception("VisitSwitchItem Exception");
        }

        public override ASTNode VisitAssignment([NotNull] p4Parser.AssignmentContext context)
        {
            IdAstNode id = new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined);
            Antlr4.Runtime.IToken symbol = Visit(context.assnOp()).Token;
            ASTNode expr = Visit(context.expr());

            return new AssignAstNode(id, symbol, expr);
        }

        public override ASTNode VisitArguments([NotNull] p4Parser.ArgumentsContext context)
        {
            List<ASTNode> arguments = new List<ASTNode>();
            foreach(IParseTree argument in context.expr())
            {
                arguments.Add(Visit(argument));
            }
            return new ArgumentsAstNode(arguments.ToArray(), null);
        }

        public override ASTNode VisitExprList([NotNull] p4Parser.ExprListContext context)
        {
            List<ASTNode> exprlist = new List<ASTNode>
            {
                Visit(context.expr())
            };

            if(context.exprList() != null)
            {
                ASTNode lowerList = Visit(context.exprList());
                foreach(ASTNode child in lowerList.Children)
                {
                    exprlist.Add(child);
                }
            }

            return new ExprListAstNode(exprlist.ToArray(), null);
        }

        public override ASTNode VisitAssnOp([NotNull] p4Parser.AssnOpContext context)
        {
            if (context.Assign() != null)
                return new ValueAstNode(context.Assign().Symbol);
            else if (context.CompoundOp() != null)
                return new ValueAstNode(context.CompoundOp().Symbol);
            throw new Exception("VisitAssnOp Exception");
        }

        public override ASTNode VisitBlock([NotNull] p4Parser.BlockContext context)
        {
            StatementAstNode Root = null;
            foreach (IParseTree stmt in context.stmt())
            {
                if (Root == null)
                    Root = new StatementAstNode(Visit(stmt), null);
                else
                    Root.Push(new StatementAstNode(Visit(stmt), null));
            }
            return Root;
        }


        public override ASTNode VisitDeclaration([NotNull] p4Parser.DeclarationContext context)
        {
            IdAstNode id;
            if (context.Assign() != null)
            {
                Antlr4.Runtime.IToken symbol = context.Assign().Symbol;
                ASTNode expr = Visit(context.expr());
                if(context.modifier() != null)
                {
                    id = new IdAstNode(context.Id().Symbol, SALType.Types[Visit(context.valuetype()).Token.Text], Visit(context.modifier()).Token);
                    return new AssignAstNode(id, symbol, expr);
                }
                else
                {
                    id = new IdAstNode(context.Id().Symbol, SALType.Types[Visit(context.valuetype()).Token.Text]);
                    return new AssignAstNode(id, symbol, expr);
                }

            }
            else
            {
                if (context.modifier() != null)
                {
                    id = new IdAstNode(context.Id().Symbol, SALType.Types[Visit(context.valuetype()).Token.Text], Visit(context.modifier()).Token);
                    return new DeclareAstNode(id, null);
                }
                else
                {
                    id = new IdAstNode(context.Id().Symbol, SALType.Types[Visit(context.valuetype()).Token.Text]);
                    return new DeclareAstNode(id, null);
                }
            }
            
        }

        public override ASTNode VisitModifier([NotNull] p4Parser.ModifierContext context)
        {
            if (context.Nonzero() != null)
                return new ValueAstNode(context.Nonzero().Symbol);
            else
            {
                IToken token = new CommonToken(p4Lexer.Number, "0");
                return new ValueAstNode(token);
            }
                
        }

        public override ASTNode VisitValuetype([NotNull] p4Parser.ValuetypeContext context)
        {
            if (context.NUMBER() != null)
            {
                return new TypeAstNode(context.NUMBER().Symbol);
            }
            else if(context.BOOL() != null)
            {
                return new TypeAstNode(context.BOOL().Symbol);
            }
            else if(context.CHAR() != null)
            {
                return new TypeAstNode(context.CHAR().Symbol);
            }
            else if(context.STRING() != null)
            {
                return new TypeAstNode(context.STRING().Symbol);
            }
            throw new Exception("VisitValueType Exception");
        }

        public override ASTNode VisitExpr([NotNull] p4Parser.ExprContext context)
        {

            ExprAstNode exprnode = (ExprAstNode) Visit(context.condExpr());
            Console.WriteLine(context.Negation()?.Symbol);
            exprnode.Negation = context.Negation() != null;

            return exprnode;
        }

        public override ASTNode VisitCondExpr([NotNull] p4Parser.CondExprContext context)
        {
            /*TODO: Add support for ternary operations */
            return Visit(context.logORexpr());
        }

        public override ASTNode VisitLogORexpr([NotNull] p4Parser.LogORexprContext context)
        {
            if(context.LogOrOp() != null)
            {
                return new LogicOrAstNode(Visit(context.logORexpr()), Visit(context.logANDexpr()), context.LogOrOp().Symbol);
            }

            return Visit(context.logANDexpr());
        }

        public override ASTNode VisitLogANDexpr([NotNull] p4Parser.LogANDexprContext context)
        {
            if(context.LogAndOp() != null)
            {
                return new LogicAndAstNode(Visit(context.logANDexpr()), Visit(context.andExpr()), context.LogAndOp().Symbol);
            }

            return Visit(context.andExpr());
        }

        public override ASTNode VisitAndExpr([NotNull] p4Parser.AndExprContext context)
        {
            if(context.EqualityOp() != null)
            {
                return new EqualityAstNode(Visit(context.andExpr()), Visit(context.relExpr()), context.EqualityOp().Symbol);
            }

            return Visit(context.relExpr());
        }
        public override ASTNode VisitRelExpr([NotNull] p4Parser.RelExprContext context)
        {
            if(context.RelOp() != null)
            {
                return new RelationalExprAstNode(Visit(context.relExpr()), Visit(context.addExpr()), context.RelOp().Symbol);
            }

            return Visit(context.addExpr());
        }
        public override ASTNode VisitAddExpr([NotNull] p4Parser.AddExprContext context)
        {
            if(context.AddOp() != null)
            {
                return new PlusAstNode(Visit(context.addExpr()), Visit(context.multExpr()), context.AddOp().Symbol);
            }
            return Visit(context.multExpr());
        }
        public override ASTNode VisitMultExpr([NotNull] p4Parser.MultExprContext context)
        {
            if(context.MultOp() != null)
            {
                return new MultAstNode(Visit(context.multExpr()), Visit(context.postExpr()), context.MultOp().Symbol);
            }
            return base.VisitMultExpr(context);
        }
        public override ASTNode VisitPostExpr([NotNull] p4Parser.PostExprContext context)
        {
            if (context.primExpr() != null)
            {
                return Visit(context.primExpr());
            }
            else if (context.Lbrace() != null)
            {
                return Visit(context.exprList());
            }
            else if (context.Lbracket() != null)
            {
                ASTNode ArrayId = new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined);

                return new ArrayAccessAstNode(ArrayId, Visit(context.expr()), null);
            }
            throw new Exception("VisitPostExpr Exception");
        }

        public override ASTNode VisitPrimExpr([NotNull] p4Parser.PrimExprContext context)
        {
            if (context.literal() != null)
            {
                return Visit(context.literal());
            }
            if(context.Lparen() != null)
            {
                return Visit(context.expr());
            }
            if(context.postfix() != null)
            {
                return Visit(context.postfix());
            }
            if(context.prefix() != null)
            {
                return Visit(context.prefix());
            }
            if(context.functioncall() != null)
            {
                return Visit(context.functioncall());
            }
            if(context.Id() != null)
            {
                return new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined);
            }
            throw new Exception("VisitPrimExpr Exception");
        }

        public override ASTNode VisitPostfix([NotNull] p4Parser.PostfixContext context)
        {
            return new PostfixExprAstNode(new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined), context.IncrementOp().Symbol);
        }

        public override ASTNode VisitPrefix([NotNull] p4Parser.PrefixContext context)
        {
            return new PrefixExprAstNode(new IdAstNode(context.Id().Symbol, SALTypeEnum.undefined), context.IncrementOp().Symbol);
        }

        public override ASTNode VisitValue([NotNull] p4Parser.ValueContext context)
        {
            if(context.Number() != null)
            {
                return new ValueAstNode(context.Number().Symbol);
            }
            else if(context.Char() != null)
            {
                return new ValueAstNode(context.Char().Symbol);
            }
            else if (context.String() != null)
            {
                return new ValueAstNode(context.String().Symbol);
            }
            else if (context.@bool() != null)
            {
                return Visit(context.@bool());
            }

            throw new Exception("VisitValue Exception");
        }

        public override ASTNode VisitBool([NotNull] p4Parser.BoolContext context)
        {
            if(context.True() != null)
            {
                return new ValueAstNode(context.True().Symbol);
            }
            else if(context.False() != null)
            {
                return new ValueAstNode(context.False().Symbol);
            }

            throw new Exception("VisitBool Exception");
        }

        public override ASTNode VisitErrorNode(IErrorNode node)
        {
            throw new Exception("This should not happen: ErrorNode Exception!");
        }
    }
}
