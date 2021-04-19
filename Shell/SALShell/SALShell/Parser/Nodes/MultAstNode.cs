using Antlr4.Runtime;

namespace SALShell.Parser
{
    public class MultAstNode : ExprAstNode
    {
        public MultAstNode(ASTNode expr1, ASTNode expr2, IToken @operator) : base(@operator)
        {
            Children.Add(expr1);
            Children.Add(expr2);
        }
    }
}