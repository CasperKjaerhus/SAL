using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class ForeachAstNode : ASTNode
    {
        public ASTNode ItemId { get; }
        public ASTNode CollectionId { get; }
        public Scope Scope { get; set; }
        public ASTNode Body { get; }
        public ForeachAstNode(ASTNode itemId, ASTNode collectionId, ASTNode body, IToken token) : base(token)
        {
            ItemId = itemId;
            CollectionId = collectionId;
            Body = body;

            Children.Add(itemId);
            Children.Add(collectionId);
            Children.Add(body);
        }
    }
}
