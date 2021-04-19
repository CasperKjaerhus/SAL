using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ParameterListAstNode : ASTNode
    {
        string Parameters { get; }

        public ParameterListAstNode(ASTNode[] parameters, IToken token) : base(token)
        {
            Children.AddRange(parameters);
            foreach (ASTNode param in Children)
            {
                Parameters += param.Token.Text;
                Parameters += ", ";
            }
        }
    }
}
