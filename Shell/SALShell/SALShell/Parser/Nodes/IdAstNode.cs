using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class IdAstNode : ExprAstNode
    {
        public SALTypeEnum Type { get; set; }
        public IToken ArraySize { get; }
        public string InoType { get; set; }
        public Symbol Symbol { get; set; }
        public bool IsParam { get; set; } = false;

        public IdAstNode(IToken idName, SALTypeEnum type) : base(idName)
        {
            Type = type;
        }
        public IdAstNode(IToken idName, SALTypeEnum type, IToken modifier) : base(idName)
        {
            Type = type;
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

            Console.WriteLine($"{Type} {Token.Text}{ArraySize?.Text}: {this.GetType()}");

            foreach (ASTNode child in Children)
            {
                child.PrintTrees(depth + 1);
            }
        }
    }
}
