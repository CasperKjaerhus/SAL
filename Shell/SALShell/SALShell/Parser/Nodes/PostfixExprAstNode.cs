using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class PostfixExprAstNode : ExprAstNode
    {
        public ASTNode Id { get; }
        public PostfixExprAstNode(ASTNode idnode, IToken @operator) : base(@operator)
        {
            Id = idnode;
            Children.Add(idnode);
        }
    }
}
