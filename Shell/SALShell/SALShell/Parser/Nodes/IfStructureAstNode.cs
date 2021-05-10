using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class IfStructureAstNode : ASTNode
    {
        public Scope Scope { get; set; }        
        public ASTNode Condition { get; set; }
        public ASTNode Body { get; set; }
        public ASTNode ElseStmt { get; set; }

        public IfStructureAstNode(ASTNode condition, ASTNode body, ASTNode elseStmt, IToken token) : base(token)
        {
            Condition = condition;
            Body = body;
            Children.Add(condition);
            Children.Add(body);
            if(elseStmt != null)
            {
                Children.Add(elseStmt);
                ElseStmt = elseStmt;
            }
        }


    }
}
