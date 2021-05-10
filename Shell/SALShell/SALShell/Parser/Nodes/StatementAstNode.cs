using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class StatementAstNode : ASTNode
    {
        public StatementAstNode NextNode { get; private set; }
        public ASTNode Action { get; }
        public StatementAstNode(ASTNode action, IToken token) : base(token)
        {
            this.Action = action;
            Children.Add(action);
        }

        public void Push(StatementAstNode item)
        {
            if (NextNode == null)
            {
                NextNode = item;
                Children.Add(item);
            }else
                NextNode.Push(item);
        }

        public override void PrintTrees(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine($"{this.GetType()}");

            Action.PrintTrees(depth + 1);
            NextNode?.PrintTrees(depth + 1);
            
        }
    }
}
