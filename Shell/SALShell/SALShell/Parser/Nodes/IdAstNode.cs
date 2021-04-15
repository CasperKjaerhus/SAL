using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class IdAstNode : ASTNode
    {
        public IToken Type { get; set; }
        public IdAstNode(IToken idName, ASTNode type) : base(idName)
        {
            Type = type?.Token;
        }
        public override void PrintTrees(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                System.Console.Write("\t");
            }
            System.Console.WriteLine($"{Type?.Text} {Token.Text}: {this.GetType()}");

            foreach (ASTNode child in Children)
            {
                child.PrintTrees(depth + 1);
            }
        }
    }
}
