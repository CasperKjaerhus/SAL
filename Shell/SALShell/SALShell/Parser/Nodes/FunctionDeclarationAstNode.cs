using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class FunctionDeclarationAstNode : ASTNode
    {
        public ASTNode Parameters { get; }
        public ASTNode Body { get; }
        public ASTNode Type { get; }
        public FunctionDeclarationAstNode(ASTNode id, ASTNode parameters, ASTNode body, ASTNode type, IToken token) : base(token)
        {
            Parameters = parameters;
            Body = body;
            Type = type;

            Children.Add(parameters);
            Children.Add(body);
            Children.Add(type);
        }
    }
}
