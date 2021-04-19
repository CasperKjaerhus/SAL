using Antlr4.Runtime;
using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class ExprAstNode : ASTNode
    {
        public bool Negation { get; set; }

        public ExprAstNode(IToken Operator) : base(Operator)
        {

        }

        public override void PrintTrees(int depth)
        {
            if(Negation)
                Console.Write("negated");

            base.PrintTrees(depth);
        }
    }
}
