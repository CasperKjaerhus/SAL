using System.Collections.Generic;
using Antlr4.Runtime;

namespace SALShell.Parser
{
    public abstract class ASTNode
    {
        public ASTNode Parent { get; }
        public List<ASTNode> Children { get; } 
        public IToken Token { get; }

        public ASTNode(IToken token)
        {
            Parent = null;
            Children = new List<ASTNode>();
            Token = token;
        }

        public virtual void PrintTrees(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                System.Console.Write("\t");
            }
            System.Console.WriteLine($"{Token?.Text}: {this.GetType()}");

            foreach(ASTNode child in Children)
            {
                child?.PrintTrees(depth+1);
            }
            
        }
    }
}