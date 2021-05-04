using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    abstract class ASTVisitor<T>
    {
        public virtual T Visit(ASTNode node)
        {
            return Visit((dynamic) node); // Using c#'s double dispatch feature
        }

        public abstract T Visit(ArgumentsAstNode node);
        public abstract T Visit(ArrayAccessAstNode node);
        public abstract T Visit(AssignAstNode node);
        public abstract T Visit(CondAstNode node);
        public abstract T Visit(DeclareAstNode node);
        public abstract T Visit(ExprAstNode node);
        public abstract T Visit(ExprListAstNode node);
        public abstract T Visit(ForAstNode node);
        public abstract T Visit(ForeachAstNode node);
        public abstract T Visit(FunctioncallAstNode node);
        public abstract T Visit(FunctionDeclarationAstNode node);
        public abstract T Visit(IdAstNode node);
        public abstract T Visit(IfStructureAstNode node);
        public abstract T Visit(ImportStatementAstNode node);
        public abstract T Visit(LogicAndAstNode node);
        public abstract T Visit(EqualityAstNode node);
        public abstract T Visit(LogicOrAstNode node);
        public abstract T Visit(MultAstNode node);
        public abstract T Visit(ParameterListAstNode node);
        public abstract T Visit(PlusAstNode node);
        public abstract T Visit(PostfixExprAstNode node);
        public abstract T Visit(PrefixExprAstNode node);
        public abstract T Visit(RelationalExprAstNode node);
        public abstract T Visit(ReturnAstNode node);
        public abstract T Visit(StatementAstNode node);
        public abstract T Visit(SwitchBodyAstNode node);
        public abstract T Visit(SwitchItemAstNode node);
        public abstract T Visit(SwitchStructureAstNode node);
        public abstract T Visit(TypeAstNode node);
        public abstract T Visit(ValueAstNode node);
        public abstract T Visit(WhileAstNode node);
    }
}
