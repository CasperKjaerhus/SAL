using Antlr4.Runtime;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ReturnAstNode : ASTNode
    {
        public ASTNode ReturnExpression { get; }
        public SALTypeEnum ReturnType { get; set; }

        public ReturnAstNode(ASTNode returnexpr, IToken token) : base(token)
        {
            ReturnExpression = returnexpr;
            Children.Add(returnexpr);
        }
    }
}
