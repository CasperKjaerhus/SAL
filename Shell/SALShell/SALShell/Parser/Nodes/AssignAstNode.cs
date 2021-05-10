using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class AssignAstNode : ASTNode
    {
        public AssignAstNode(ASTNode id, IToken assign, ASTNode expr) : base(assign)
        {

            Id = id;
            Expr = expr;
            Children.Add(id);
            Children.Add(expr);
        }

        public ASTNode Id { get; set; }

        public ASTNode Expr { get; set; }
        public int ArraySize { get; set; }
        public string InoType { get; set; }
        public Symbol Sym { get; set; }
    }
}
