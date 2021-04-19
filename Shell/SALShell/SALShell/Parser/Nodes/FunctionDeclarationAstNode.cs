﻿using Antlr4.Runtime;
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