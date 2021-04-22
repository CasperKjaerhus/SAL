using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class SymbolTableVisitor : ASTVisitor<TypeInfo>
    {
        public override TypeInfo Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(AssignAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(DeclareAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(FunctioncallAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(FunctionDeclarationAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(IdAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(IfStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicAndAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicEqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(MultAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(PlusAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(RelationalExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ReturnAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(StatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ValueAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }
    }
}
