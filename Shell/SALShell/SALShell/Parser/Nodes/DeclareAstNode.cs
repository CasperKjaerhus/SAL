using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class DeclareAstNode : ASTNode
    {
        public ASTNode Id { get; }
        public ASTNode Type { get; }
        public DeclareAstNode(ASTNode id, ASTNode type, IToken token) : base(token)
        {
            Id = id;
            Type = type;

            Children.Add(id);
            Children.Add(type);
        }
    }
}
