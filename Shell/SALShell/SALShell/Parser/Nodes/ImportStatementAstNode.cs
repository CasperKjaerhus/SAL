﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ImportStatementAstNode : ASTNode
    {
        public ImportStatementAstNode(IToken token) : base(token)
        {
        }
    }
}