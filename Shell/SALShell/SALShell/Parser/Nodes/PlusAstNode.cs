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
            Children.Add(expr1);
            Children.Add(expr2);
        }
    }
}