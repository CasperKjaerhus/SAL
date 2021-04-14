using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class RelationalExprAstNode : ExprAstNode
    {
        public RelationalExprAstNode(ASTNode expr1, ASTNode expr2, IToken Operator) : base(Operator)
        {
            Children.Add(expr1);
            Children.Add(expr2);
        }
    }
}
