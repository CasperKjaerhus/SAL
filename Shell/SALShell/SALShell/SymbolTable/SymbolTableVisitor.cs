using Antlr4.Runtime;
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
            TypeInfo info = Visit(node.Id);

            return new AssignmentTypeInfo(info.Type);
        }

        public override TypeInfo Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(DeclareAstNode node)
        {
            TypeInfo info = Visit(node.Id);

            return new DeclTypeInfo(info.Type);
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
            TypeInfo info = Visit(node.FunctionId);

            return new FuncCallTypeInfo(info.Type);
        }

        //should return the type, and it's parameters return type
        public override TypeInfo Visit(FunctionDeclarationAstNode node)
        {
            TypeInfo info = Visit(node.Id);
            ASTNode Paraminfo = node.Parameters;
            List<IToken> tokens = new List<IToken>();

            foreach (IdAstNode param in Paraminfo.Children)
            {
                tokens.Add(param.Type);
            }

            FuncTypeInfo funcTypeInfo = new FuncTypeInfo(info.Type, tokens);
            return funcTypeInfo;
        }

        public override TypeInfo Visit(IdAstNode node)
        {

            return new IdTypeInfo(node.ArraySize, node.Type);
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

        public override TypeInfo Visit(EqualityAstNode node)
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
            return Visit(node.Condition);
        }
    }
}
