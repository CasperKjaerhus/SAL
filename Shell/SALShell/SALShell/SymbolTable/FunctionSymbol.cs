using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
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
