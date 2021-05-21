using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class PrefixExprAstNode : ExprAstNode
    {
        public ASTNode Id { get; set; }
        public PrefixExprAstNode(ASTNode idnode, IToken @operator) : base(@operator)
        {
            Id = idnode;
            Children.Add(idnode);
        }
    }
}
