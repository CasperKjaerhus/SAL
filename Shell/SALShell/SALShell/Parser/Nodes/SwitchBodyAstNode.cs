using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class SwitchBodyAstNode : ASTNode
    {
        public SwitchBodyAstNode(ASTNode[] switchItems, IToken token) : base(token)
        {
            Children.AddRange(switchItems);
        }
    }
}
