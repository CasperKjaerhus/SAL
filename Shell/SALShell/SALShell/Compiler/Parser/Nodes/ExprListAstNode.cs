using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ExprListAstNode : ExprAstNode
    {
        public ExprListAstNode(ASTNode[] exprs,IToken token) : base(token)
        {
            Children.AddRange(exprs);
        }
    }
}
