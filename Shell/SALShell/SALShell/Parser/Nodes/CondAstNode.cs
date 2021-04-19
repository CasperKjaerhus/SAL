using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class CondAstNode : ExprAstNode
    {
        public CondAstNode(IToken token) : base(token)
        {

        }
    }
}
