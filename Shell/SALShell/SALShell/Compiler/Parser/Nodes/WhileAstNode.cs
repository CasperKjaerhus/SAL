using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class WhileAstNode : ASTNode
    {
        public ASTNode Condition { get; }
        public ASTNode Body { get; }
        public Scope Scope { get; set; }
        public WhileAstNode(ASTNode condition, ASTNode body, IToken token) : base(token)
        {
            Condition = condition;
            Body = body;

            Children.Add(condition);
            Children.Add(Body);
        }
    }
}
