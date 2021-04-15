using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class SwitchStructureAstNode : ASTNode
    {
        public ASTNode ConditionalValue { get; }
        public SwitchStructureAstNode(ASTNode conditionalvalue, ASTNode switchItems, IToken token) : base(token)
        {
            ConditionalValue = conditionalvalue;
            Children.Add(switchItems);
        }
        public override void PrintTrees(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine($"{Token.Text}: {this.GetType()}");

            ConditionalValue.PrintTrees(depth + 1);

            foreach (ASTNode child in Children)
            {
                child.PrintTrees(depth + 1);
            }
        }
    }
}
