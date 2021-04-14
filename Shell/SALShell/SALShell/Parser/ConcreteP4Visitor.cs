using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Parser;
using Antlr4.Runtime.Tree;

namespace SALShell.Parser
{
    public class ConcreteP4Visitor : p4BaseVisitor<ASTNode>
    {
        public override ASTNode VisitDeclaration([NotNull] p4Parser.DeclarationContext context)
        {
            //Console.WriteLine(context.GetText());

            IdAstNode id = new IdAstNode(context.Id().Symbol, Visit(context.valuetype()));
            Antlr4.Runtime.IToken symbol = context.Assign().Symbol;
            ASTNode expr = Visit(context.expr());

            return new AssignAstNode(id, symbol, expr);
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
            throw new Exception("Parse errors lol");
        }

        public override ASTNode VisitExpr([NotNull] p4Parser.ExprContext context)
        {
            /*TODO: (Comma expr)* should be supported*/

            ExprAstNode exprnode = (ExprAstNode) Visit(context.condExpr());
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
                return new LogicEqualityAstNode(Visit(context.andExpr()), Visit(context.relExpr()), context.EqualityOp().Symbol);
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
            if(context.primExpr() != null)
            {
                return Visit(context.primExpr());
            }
            else if(context.Lbrace() != null)
            {
                return Visit(context.exprList());
            }
            else if(context.Lbracket() != null)
            {
                /*TODO: ARRAY ACCESS NODES*/
            }
            else if(context.Dot() != null)
            {
                /*TODO: Direct component selection*/
            }
            throw new Exception("Wrong parse get rekt");
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
            throw new Exception("Wrong parse get rekt");
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

            throw new Exception("Parse error lul");
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

            throw new Exception("Parse Error lulskibreski");
        }
    }
}
