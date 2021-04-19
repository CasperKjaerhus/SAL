using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ForAstNode : ASTNode
    {
        public ASTNode Iterator { get; }
        public ASTNode StartValue { get; }
        public ASTNode EndValue { get; }
        public ASTNode Body { get; }
        public ASTNode Step { get; }
        public ForAstNode(ASTNode iterator, ASTNode startValue, ASTNode endValue, ASTNode step, ASTNode body, IToken token) : base(token)
        {
            Iterator = iterator;
            StartValue = startValue;
            EndValue = endValue;
            Body = body;
            Step = step;

            Children.Add(iterator);
            Children.Add(startValue);
            Children.Add(endValue);
            Children.Add(step);
            Children.Add(body);
        }
    }
}
