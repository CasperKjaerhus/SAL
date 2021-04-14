using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class PrefixExprAstNode : ExprAstNode
    {
        public PrefixExprAstNode(ASTNode idnode, IToken Operator) : base(Operator)
        {
            Children.Add(idnode);
        }
    }
}
