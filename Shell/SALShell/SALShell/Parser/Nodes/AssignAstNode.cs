using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class AssignAstNode : ASTNode
    {
        public AssignAstNode(ASTNode id, IToken Assign, ASTNode Expr) : base(Assign)
        {
            Children.Add(id);
            Children.Add(Expr);
        }
    }
}
