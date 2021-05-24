using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ParameterListAstNode : ASTNode
    {
        public ParameterListAstNode(ASTNode[] parameters, IToken token) : base(token)
        {
            Children.AddRange(parameters);
        }
    }
}
