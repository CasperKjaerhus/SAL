using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class WhileAstNode : ASTNode
    {
        public ASTNode Condition { get; }
        public ASTNode Body { get; }
        public Scope Scope { get; set; }
        public WhileAstNode(ASTNode condition, ASTNode body, IToken token) : base(token)
        {
            Condition = condition;
            Body = body;

            Children.Add(condition);
            Children.Add(Body);
        }
    }
}
