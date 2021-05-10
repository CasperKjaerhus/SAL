using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class ArgumentsAstNode : ASTNode
    {
        public ArgumentsAstNode(ASTNode[] arguments, IToken token) : base(token)
        {
            Children.AddRange(arguments);
        }
    }
}
