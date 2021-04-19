using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class IdAstNode : ExprAstNode
    {
        public IToken Type { get; set; }
        public IToken ArraySize { get; }
        public IdAstNode(IToken idName, ASTNode type) : base(idName)
        {
            Type = type?.Token;
        }
        public IdAstNode(IToken idName, ASTNode type, IToken modifier) : base(idName)
        {
            Type = type?.Token;
            ArraySize = modifier;
        }
        public override void PrintTrees(int depth)
        {
            if (Negation)
                Console.Write("Negated");
            for (int i = 0; i < depth; i++)
            {
               Console.Write("\t");
            }

            Console.WriteLine($"{Type?.Text} {Token.Text}{ArraySize?.Text}: {this.GetType()}");

            foreach (ASTNode child in Children)
            {
                child.PrintTrees(depth + 1);
            }
        }
    }
}
