using System;
using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public abstract class ExprAstNode : ASTNode
    {
        public bool Negation { get; set; }

        public ExprAstNode(IToken @operator) : base(@operator)
        {

        }

        public override void PrintTrees(int depth)
        {
            if(Negation)
                Console.Write("Negation");

            base.PrintTrees(depth);
        }
    }
}
