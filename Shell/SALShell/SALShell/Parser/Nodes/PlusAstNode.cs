using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class PlusAstNode : ExprAstNode
    {

        public PlusAstNode(ASTNode expr1, ASTNode expr2, IToken token) : base(token)
        {
            E1 = expr1;
            E2 = expr2;
            Children.Add(expr1);
            Children.Add(expr2);
        }

        public ASTNode E1 { get; set; }

        public ASTNode E2 { get; set; }
    }
}