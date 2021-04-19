using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class IfStructureAstNode : ASTNode
    {
        public IfStructureAstNode(ASTNode expr, ASTNode body, ASTNode elseStmt, IToken token) : base(token)
        {
            Children.Add(expr);
            Children.Add(body);
            if(elseStmt != null)
            {
                Children.Add(elseStmt);
            }
        }
    }
}
