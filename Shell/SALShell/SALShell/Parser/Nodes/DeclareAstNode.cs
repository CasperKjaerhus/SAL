using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class DeclareAstNode : ASTNode
    {
        public ASTNode Id { get; }
        public DeclareAstNode(ASTNode id, IToken token) : base(token)
        {
            Id = id;

            Children.Add(id);
        }
    }
}
