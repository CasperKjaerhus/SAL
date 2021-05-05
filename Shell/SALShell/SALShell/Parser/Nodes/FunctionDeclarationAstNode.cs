using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class FunctionDeclarationAstNode : ASTNode
    {
        public ASTNode Id { get; }
        public ASTNode Parameters { get; }
        public ASTNode Body { get; }
        public Symbol Sym { get; set; }

        public FunctionDeclarationAstNode(ASTNode id, ASTNode parameters, ASTNode body, IToken token) : base(token)
        {
            Id = id;
            Parameters = parameters;
            Body = body;

            Children.Add(id);
            Children.Add(parameters);
            Children.Add(body);
        }
    }
}
