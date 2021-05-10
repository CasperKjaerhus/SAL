using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class SwitchBodyAstNode : ASTNode
    {
        public Scope Scope { get; set; }
        public SwitchBodyAstNode(ASTNode[] switchItems, IToken token) : base(token)
        {
            Children.AddRange(switchItems);
        }
    }
}
