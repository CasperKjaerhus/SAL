using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public abstract class ASTVisitor<T>
    {
        public virtual T Visit(ASTNode node)
        {
            if(node != null)
            {
                return Visit((dynamic) node); // Using c#'s double dispatch feature
            }
            return default;
        }

        public virtual T Visit(ArgumentsAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ArrayAccessAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(AssignAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(CondAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(DeclareAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ExprListAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ForAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ForeachAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(FunctioncallAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(FunctionDeclarationAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(IdAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(IfStructureAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ImportStatementAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(LogicAndAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(EqualityAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(LogicOrAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(MultAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ParameterListAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(PlusAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(PostfixExprAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(PrefixExprAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(RelationalExprAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ReturnAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(StatementAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(SwitchBodyAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(SwitchItemAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(SwitchStructureAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(TypeAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(ValueAstNode node)
        {
            return DefaultCase(node);
        }
        public virtual T Visit(WhileAstNode node)
        {
            return DefaultCase(node);
        }
        private T DefaultCase(ASTNode node)
        {
            foreach(ASTNode child in node.Children)
            {
                if(child != null)
                    Visit(child);
            }
            return default;
        }
    }
}
