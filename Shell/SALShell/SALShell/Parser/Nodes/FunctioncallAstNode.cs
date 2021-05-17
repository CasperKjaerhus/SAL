using Antlr4.Runtime;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Parser
{
    public class FunctioncallAstNode : ExprAstNode
    {
        public ASTNode FunctionId { get; }
        public ASTNode Arguments { get; }
        public FunctionSymbol Symbol { get; set; }
        public string InoType { get; set; }
        public FunctioncallAstNode(ASTNode functionId, ASTNode arguments, IToken token) : base(token)
        {
            FunctionId = functionId;
            Arguments = arguments;

            Children.Add(functionId);
            Children.Add(arguments);
        }
    }
}
