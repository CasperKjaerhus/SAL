using Antlr4.Runtime;
using SALShell.CodeGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ParameterListAstNode : ASTNode
    {
        public ParameterListAstNode(ASTNode[] parameters, IToken token) : base(token)
        {
            Children.AddRange(parameters);
        }
    }
}
