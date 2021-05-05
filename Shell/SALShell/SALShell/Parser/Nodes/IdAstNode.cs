using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class IdAstNode : ExprAstNode
    {
        public SALType Type { get; set; }
        public IToken ArraySize { get; }
        public Symbol Sym { get; set; }

        public IdAstNode(IToken idName, ASTNode type) : base(idName)
        {
            Type = ResolveType(type);
        }
        public IdAstNode(IToken idName, ASTNode type, IToken modifier) : base(idName)
        {
            Type = ResolveType(type);
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

        private SALType ResolveType(ASTNode type)
        {
            SALType returnType;
            switch (type?.Token.Text.ToLower())
            {
                case "string":
                    returnType = SALType.@string;
                    break;
                case "number":
                    returnType = SALType.number;
                    break;
                case "true":
                case "false":
                    returnType = SALType.@bool;
                    break;
                case "char":
                    returnType = SALType.@char;
                    break;
                case "void":
                    returnType = SALType.@void;
                    break;
                default:
                    returnType = SALType.error;
                    break;
            }

            return returnType;
        }
    }
}
