using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class AssignAstNode : ASTNode
    {
        public AssignAstNode(ASTNode id, IToken assign, ASTNode expr) : base(assign)
        {

            Id = id;
            Expr = expr;
            Children.Add(id);
            Children.Add(expr);
        }

        public ASTNode Id { get; set; }

        public ASTNode Expr { get; set; }

        public Symbol Symbol { get; set; }
        public InoTypeEnum InoType { get; set; }
    }
}
