using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SALShell.CodeGen
{
    class CodeGenVisitor : ASTVisitor<string>
    {

        public override string Visit(ArgumentsAstNode node)
        {
            string arguments = "";
            foreach (ASTNode child in node.Children)
            {
                arguments += Visit(child) + ", ";
            }

            return arguments;
        }

        public override string Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(AssignAstNode node)
        {
            string AssignmentCode = Visit(node.Id) +  " = " + Visit(node.Expr);

            return AssignmentCode;
        }

        public override string Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(DeclareAstNode node)
        {
            return Visit(node.Id);
        }

        public override string Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(FunctioncallAstNode node)
        {
            return Visit(node.FunctionId) + $"({Visit(node.Arguments)})";
        }

        public override string Visit(FunctionDeclarationAstNode node)
        {
            return Visit(node.Id) + $"({Visit(node.Parameters)})" + Visit(node.Body);
        }

        public override string Visit(IdAstNode node)
        {
            string IdCode = "";

            if (node.Type != null)
                IdCode += node.Type.Text + " ";

            IdCode += node.Token.Text;

            if (node.ArraySize != null)
                IdCode += $"[{node.ArraySize}]";

            return IdCode;
        }

        public override string Visit(IfStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(LogicAndAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(EqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(MultAstNode node)
        {
            return $"{node.Left.Token.Text} * {node.Right.Token.Text}";
        }

        public override string Visit(ParameterListAstNode node)
        {
            string parameters = "";
            foreach (ASTNode child in node.Children)
            {
                parameters += Visit(child);
                parameters += ", ";
            }
            return parameters;
        }

        public override string Visit(PlusAstNode node)
        {
            return $"{node.Left.Token.Text} + {node.Right.Token.Text}";
        }

        public override string Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(RelationalExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ReturnAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(StatementAstNode node)
        {
            return Visit(node.Action);
        }

        public override string Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ValueAstNode node)
        {
            return node.Token.Text;
        }

        public override string Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }
    }
}
