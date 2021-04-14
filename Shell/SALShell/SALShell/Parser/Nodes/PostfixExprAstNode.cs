using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class PostfixExprAstNode : ExprAstNode
    {
        public PostfixExprAstNode(ASTNode idnode, IToken Operator) : base(Operator)
        {
            Children.Add(idnode);
        }
    }
}
