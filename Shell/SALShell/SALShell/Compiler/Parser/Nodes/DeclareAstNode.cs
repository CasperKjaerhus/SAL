using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class DeclareAstNode : ASTNode
    {
        public ASTNode Id { get; }
        public Symbol Symbol { get; set; }
        public InoTypeEnum InoType { get; set; }
        public DeclareAstNode(ASTNode id, IToken token) : base(token)
        {
            Id = id;

            Children.Add(id);
        }
    }
}
