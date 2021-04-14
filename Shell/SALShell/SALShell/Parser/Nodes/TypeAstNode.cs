using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class TypeAstNode : ASTNode
    {
        public TypeAstNode(IToken token) : base(token)
        {
        }
    }
}
