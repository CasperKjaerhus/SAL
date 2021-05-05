using Antlr4.Runtime;

namespace SALShell.Parser
{
    public class MultAstNode : ExprAstNode
    {
        public ASTNode Left { get; set; }
        public ASTNode Right { get; set; }
        public MultAstNode(ASTNode expr1, ASTNode expr2, IToken @operator) : base(@operator)
        {
            Left = expr1;
            Right = expr2;

            Children.Add(expr1);
            Children.Add(expr2);
        }
    }
}