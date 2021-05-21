using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class PostfixExprAstNode : ExprAstNode
    {
        public ASTNode Id { get; }
        public PostfixExprAstNode(ASTNode idnode, IToken @operator) : base(@operator)
        {
            Id = idnode;
            Children.Add(idnode);
        }
    }
}
