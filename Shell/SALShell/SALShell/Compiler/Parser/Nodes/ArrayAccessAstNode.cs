using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ArrayAccessAstNode : ExprAstNode
    {
        public ASTNode Id { get; }
        public ASTNode IndexExpression { get; }
        public Symbol Symbol { get; set; }
        public ArrayAccessAstNode(ASTNode id, ASTNode indexExpr, IToken token) : base(token)
        {
            Id = id;
            IndexExpression = indexExpr;

            Children.Add(Id);
            Children.Add(IndexExpression);
        }
    }
}
