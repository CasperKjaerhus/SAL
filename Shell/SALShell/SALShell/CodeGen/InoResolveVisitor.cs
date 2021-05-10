using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.CodeGen
{
    class InoResolveVisitor : ASTVisitor<object>
    {
        Dictionary<Symbol, string> IdValues = new Dictionary<Symbol, string>(); 

        public override object Visit(ArgumentsAstNode node)
        {
            return null;
        }

        public override object Visit(ArrayAccessAstNode node)
        {
            return null;
        }

        public override object Visit(AssignAstNode node)
        {

            if (node.Sym.Type.Type.Text == "number")
            {
                EvaluateInoAssignment(node);
            }
            return null;
        }

        private string EvaluateInoAssignment(AssignAstNode node)
        {
            string value = "";

            if (node.Expr is ValueAstNode)
            {
                value += Visit(node.Expr);
                node.InoType = value;
                IdValues.Add(node.Sym, value);
            }else if(node.Expr is IdAstNode)
            {
                value += Visit(node.Expr);
                node.InoType = value;
                IdValues.Add(node.Sym, value);
            }

            return value;
        }

        public override object Visit(CondAstNode node)
        {
            return null;
        }

        public override object Visit(DeclareAstNode node)
        {
            return null;
        }

        public override object Visit(ExprAstNode node)
        {
            return null;
        }

        public override object Visit(ExprListAstNode node)
        {
            return null;
        }

        public override object Visit(ForAstNode node)
        {
            return null;
        }

        public override object Visit(ForeachAstNode node)
        {
            return null;
        }

        public override object Visit(FunctioncallAstNode node)
        {
            return null;
        }

        public override object Visit(FunctionDeclarationAstNode node)
        {
            return null;
        }

        public override object Visit(IdAstNode node)
        {
            IdValues.TryGetValue(node.Sym, out string val);
            return val;
        }

        public override object Visit(IfStructureAstNode node)
        {
            return null;
        }

        public override object Visit(ImportStatementAstNode node)
        {
            return null;
        }

        public override object Visit(LogicAndAstNode node)
        {
            return null;
        }

        public override object Visit(EqualityAstNode node)
        {
            return null;
        }

        public override object Visit(LogicOrAstNode node)
        {
            return null;
        }

        public override object Visit(MultAstNode node)
        {
            string leftval = "";
            string rightval = "";
            if(node.Left is IdAstNode)
            {
                leftval += Visit(node.Left);
            }

            if(node.Right is IdAstNode)
            {
                rightval += Visit(node.Right);
            }

            if(rightval == "float" || leftval == "float")
            {
                return "float";
            }
        }

        public override object Visit(ParameterListAstNode node)
        {
            return null;
        }

        public override object Visit(PlusAstNode node)
        {
            return null;
        }

        public override object Visit(PostfixExprAstNode node)
        {
            return null;
        }

        public override object Visit(PrefixExprAstNode node)
        {
            return null;
        }

        public override object Visit(RelationalExprAstNode node)
        {
            return null;
        }

        public override object Visit(ReturnAstNode node)
        {
            return null;
        }

        public override object Visit(StatementAstNode node)
        {
            foreach (ASTNode child in node.Children)
            {
                if(child is AssignAstNode || child is DeclareAstNode)
                {
                    Visit(child);
                }
            }

            return null;
        }

        public override object Visit(SwitchBodyAstNode node)
        {
            return null;
        }

        public override object Visit(SwitchItemAstNode node)
        {
            return null;
        }

        public override object Visit(SwitchStructureAstNode node)
        {
            return null;
        }

        public override object Visit(TypeAstNode node)
        {
            return null;
        }

        public override object Visit(ValueAstNode node)
        {
            if (node.Token.Text.Contains("."))
            {
                return "float";
            }
            else
            {
                return "int";
            }
        }

        public override object Visit(WhileAstNode node)
        {
            return null;
        }
    }
}
