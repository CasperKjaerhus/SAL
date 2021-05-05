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
            Expr = expr;
            Body = body;
            Children.Add(expr);
            Children.Add(body);
            if(elseStmt != null)
            {
                Children.Add(elseStmt);
                ElseStmt = elseStmt;
            }
        }

        public ASTNode Expr { get; set; }

        public ASTNode Body { get; set; }

        public ASTNode ElseStmt { get; set; }
    }
}
