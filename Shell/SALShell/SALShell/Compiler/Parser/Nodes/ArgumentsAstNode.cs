using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ArgumentsAstNode : ASTNode
    {
        public ArgumentsAstNode(ASTNode[] arguments, IToken token) : base(token)
        {
            Children.AddRange(arguments);
        }
    }
}
