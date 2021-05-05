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

        private SALTypeEnum ResolveType(ASTNode type)
        {
            SALTypeEnum returnType;
            switch (type?.Token.Text.ToLower())
            {
                case "string":
                    returnType = SALTypeEnum.@string;
                    break;
                case "number":
                    returnType = SALTypeEnum.number;
                    break;
                case "true":
                case "false":
                    returnType = SALTypeEnum.@bool;
                    break;
                case "char":
                    returnType = SALTypeEnum.@char;
                    break;
                case "void":
                    returnType = SALTypeEnum.@void;
                    break;
                default:
                    returnType = SALTypeEnum.error;
                    break;
            }

            return returnType;
        }
    }
}
