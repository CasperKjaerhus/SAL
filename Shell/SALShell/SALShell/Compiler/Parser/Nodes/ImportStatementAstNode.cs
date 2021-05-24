using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ImportStatementAstNode : ASTNode
    {
        public ImportStatementAstNode(IToken token) : base(token)
        {
        }
    }
}
