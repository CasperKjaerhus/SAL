using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ValueAstNode : ExprAstNode
    {
        public ValueAstNode(IToken value) : base(value)
        {
        }
    }
}
