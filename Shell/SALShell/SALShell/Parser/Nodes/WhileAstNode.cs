using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class WhileAstNode : ASTNode
    {
        public ASTNode Condition { get; }
        public ASTNode Body { get; }
        public WhileAstNode(ASTNode condition, ASTNode body, IToken token) : base(token)
        {
            Condition = condition;
            Body = body;

            Children.Add(condition);
            Children.Add(Body);
        }
    }
}
