using System;
using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class IdAstNode : ExprAstNode
    {
        public SALTypeEnum Type { get; set; }
        public int? ArraySize { get; }
        public bool IsParam { get; set; }
        public InoTypeEnum InoType { get; set; }
        public Symbol Symbol { get; set; }

        public IdAstNode(IToken idName, SALTypeEnum type) : base(idName)
        {
            Type = type;
        }
        public IdAstNode(IToken idName, SALTypeEnum type, IToken modifier) : base(idName)
        {
            Type = type;
            ArraySize = Convert.ToInt32(modifier.Text);
        }

        public override void PrintTrees(int depth)
        {
            if (Negation)
                Console.Write("Negated");
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t");
            }

            Console.WriteLine($"{Type} {Token.Text}{ArraySize}: {this.GetType()}");

            foreach (ASTNode child in Children)
            {
                child.PrintTrees(depth + 1);
            }
        }
    }
}
