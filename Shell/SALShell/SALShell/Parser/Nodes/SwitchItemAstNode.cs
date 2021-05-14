using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class SwitchItemAstNode : ASTNode
    {
        public ASTNode Value { get; }
        public ASTNode Block { get; }
        public bool IsBreaked { get; }
        public SwitchItemAstNode(ASTNode value, ASTNode block, bool isBreaked, IToken token) : base(token)
        {
            Value = value;
            Block = block;
            IsBreaked = isBreaked;

            Children.Add(block);
        }
        public override void PrintTrees(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine($"{Token.Text}: {this.GetType()}");

            Value.PrintTrees(depth + 1);
            Block?.PrintTrees(depth + 1);
        }
    }
}
