using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class EqualityAstNode : ExprAstNode
    {
        public EqualityAstNode(ASTNode expr1, ASTNode expr2, IToken @operator) : base(@operator)
        {
            Left = expr1;
            Right = expr2;

            Children.Add(expr1);
            Children.Add(expr2);
        }

        public ASTNode Right { get; set; }

        public ASTNode Left { get; set; }
    }
}
