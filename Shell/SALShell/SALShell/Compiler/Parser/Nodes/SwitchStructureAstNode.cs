using System;
using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class SwitchStructureAstNode : ASTNode
    {
        public ASTNode ConditionalValue { get; }
        public ASTNode SwitchBody { get; }
        public SwitchStructureAstNode(ASTNode conditionalvalue, ASTNode switchBody, IToken token) : base(token)
        {
            ConditionalValue = conditionalvalue;
            SwitchBody = switchBody;
            Children.Add(switchBody);
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
