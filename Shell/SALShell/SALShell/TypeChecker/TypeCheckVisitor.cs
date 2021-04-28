using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SALShell.Parser;

namespace SALShell.TypeChecker
{
    class TypeCheckVisitor : ASTVisitor<SALType>
    {
        public List<TypeError> TypeErrors = new List<TypeError>();
        public TypeCheckVisitor(ASTNode tree)
        {
        }

        public override SALType Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(AssignAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(DeclareAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(FunctioncallAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(FunctionDeclarationAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(IdAstNode node)
        {
            return SymbolTable.RetrieveSymbol(node.Token.Text).Type;
        }

        public override SALType Visit(IfStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(LogicAndAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(LogicEqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(MultAstNode node)
        {
            SALType expr1 = Visit(node.Left);
            SALType expr2 = Visit(node.Right);

            if(expr1 != expr2)
            {
                TypeErrors.Add(new TypeError(node.Token.Line, $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
            }
            return expr1;
        }

        public override SALType Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(PlusAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(RelationalExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ReturnAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(StatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ValueAstNode node)
        {
            return node.Type;
        }

        public override SALType Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }
    }
}
