using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ArrayAccessAstNode : ExprAstNode
    {
        public ASTNode Id { get; }
        public ASTNode IndexExpression { get; }
        public ArrayAccessAstNode(ASTNode id, ASTNode indexExpr, IToken token) : base(token)
        {
            Id = id;
            IndexExpression = indexExpr;

            Children.Add(Id);
            Children.Add(IndexExpression);
        }
    }
}
