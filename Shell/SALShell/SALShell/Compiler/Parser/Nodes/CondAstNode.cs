using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class CondAstNode : ExprAstNode
    {
        public CondAstNode(IToken token) : base(token)
        {
        }
    }
}
