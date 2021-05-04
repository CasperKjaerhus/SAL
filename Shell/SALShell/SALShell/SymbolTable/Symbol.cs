using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class Symbol
    {
        public string scopeName { get; }
        public string SymbolName { get; }
        public TypeInfo Type { get; }
        public int Depth { get; }

        public Symbol(string symbolName, TypeInfo type, int depth, string scopename)
        {
            SymbolName = symbolName;
            Type = type;
            Depth = depth;
            scopeName = scopename;
        }

        public override string ToString()
        {
            return $"{SymbolName} declared in: {scopeName}, at depth: {Depth}";
        }
    }
}
