using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ExprListAstNode : ExprAstNode
    {
        public ExprListAstNode(ASTNode[] exprs,IToken token) : base(token)
        {
            Children.AddRange(exprs);
        }
    }
}
