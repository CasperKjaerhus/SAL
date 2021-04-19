using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class LogicEqualityAstNode : ExprAstNode
    {
        public LogicEqualityAstNode(ASTNode expr1, ASTNode expr2, IToken @operator) : base(@operator)
        {
            Children.Add(expr1);
            Children.Add(expr2);
        }
    }
}
