using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class IfStructureAstNode : ASTNode
    {
        public IfStructureAstNode(ASTNode expr, ASTNode Body, ASTNode ElseStmt, IToken token) : base(token)
        {
            Children.Add(expr);
            Children.Add(Body);
            if(ElseStmt != null)
            {
                Children.Add(ElseStmt);
            }
        }
    }
}
