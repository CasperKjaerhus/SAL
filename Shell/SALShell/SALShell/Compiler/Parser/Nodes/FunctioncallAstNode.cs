using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class FunctioncallAstNode : ExprAstNode
    {
        public ASTNode FunctionId { get; }
        public ASTNode Arguments { get; }
        public FunctionSymbol Symbol { get; set; }
        public InoTypeEnum InoType { get; set; }
        public FunctioncallAstNode(ASTNode functionId, ASTNode arguments, IToken token) : base(token)
        {
            FunctionId = functionId;
            Arguments = arguments;

            Children.Add(functionId);
            Children.Add(arguments);
        }
    }
}
