using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class FunctioncallAstNode : ExprAstNode
    {
        public ASTNode FunctionId { get; }
        public ASTNode Arguments { get; }
        public FunctioncallAstNode(ASTNode functionId, ASTNode arguments, IToken token) : base(token)
        {
            FunctionId = functionId;
            Arguments = arguments;

            Children.Add(functionId);
            Children.Add(arguments);
        }
    }
}
