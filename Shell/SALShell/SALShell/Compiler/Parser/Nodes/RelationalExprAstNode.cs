using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class RelationalExprAstNode : ExprAstNode
    {
        public RelationalExprAstNode(ASTNode expr1, ASTNode expr2, IToken @operator) : base(@operator)
        {
            Left = expr1;
            Right = expr2;

            Children.Add(expr1);
            Children.Add(expr2);
        }

        public ASTNode Left { get; set; }

        public ASTNode Right { get; set; }
    }
}
