using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class SwitchBodyAstNode : ASTNode
    {
        public Scope Scope { get; set; }
        public SwitchBodyAstNode(ASTNode[] switchItems, IToken token) : base(token)
        {
            Children.AddRange(switchItems);
        }
    }
}
