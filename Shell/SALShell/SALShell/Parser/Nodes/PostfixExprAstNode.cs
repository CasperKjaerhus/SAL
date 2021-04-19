using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class PostfixExprAstNode : ExprAstNode
    {
        public PostfixExprAstNode(ASTNode idnode, IToken @operator) : base(@operator)
        {
            Children.Add(idnode);
        }
    }
}
