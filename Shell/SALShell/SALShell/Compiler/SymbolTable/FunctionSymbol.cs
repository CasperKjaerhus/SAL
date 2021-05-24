using System.Collections.Generic;
using SALShell.Compiler.Parser;

namespace SALShell.Compiler.SymbolTable
{
    public class FunctionSymbol : Symbol
    {
        public List<Symbol> ParameterSymbols { get; }
        public FunctionSymbol(Scope scope, string name, SALTypeEnum type, List<Symbol> parameterSymbols) : base(scope, name, type)
        {
            ParameterSymbols = parameterSymbols;
        }
    }
}
