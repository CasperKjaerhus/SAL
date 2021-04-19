using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    class ForeachAstNode : ASTNode
    {
        public ASTNode ItemId { get; }
        public ASTNode CollectionId { get; }
        public ForeachAstNode(ASTNode itemId, ASTNode collectionId, IToken token) : base(token)
        {
            ItemId = itemId;
            CollectionId = collectionId;

            Children.Add(itemId);
            Children.Add(collectionId);
        }
    }
}
