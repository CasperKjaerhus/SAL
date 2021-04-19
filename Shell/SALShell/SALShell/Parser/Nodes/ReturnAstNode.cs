using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ReturnAstNode : ASTNode
    {
        public ASTNode ReturnExpression { get; }

        public ReturnAstNode(ASTNode returnexpr, IToken token) : base(token)
        {
            ReturnExpression = returnexpr;
            Children.Add(returnexpr);
        }
    }
}
