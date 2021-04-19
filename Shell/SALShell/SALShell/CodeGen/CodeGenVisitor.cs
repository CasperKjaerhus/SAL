using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.CodeGen
{
    class CodeGenVisitor : ASTVisitor<string>
    {
        public override string Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(AssignAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(DeclareAstNode node)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string Visit(FunctionDeclarationAstNode node)
        {
            string typeAndId = Visit(node.Id);
            string Params = Visit(node.Parameters);
            string FuncDecl = typeAndId + " " + Params;


        }

        public override string Visit(IdAstNode node)
        {
            string IdentifierInfo = node.Type.Text;
            IdentifierInfo += " ";
            IdentifierInfo += node.Token.Text;

            return IdentifierInfo;
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

        public override string Visit(LogicEqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(MultAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ParameterListAstNode node)
        {
            string parameters = "";
            foreach (ASTNode child in node.Children)
            {
                parameters += child.Token.Text;
                parameters += ", ";
            }
            return parameters;
        }

        public override string Visit(PlusAstNode node)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }
    }
}
