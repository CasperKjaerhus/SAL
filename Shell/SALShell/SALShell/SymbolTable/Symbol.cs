using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class Symbol
    {
        public Symbol(string symbolName, TypeInfo type, int depth, string scopeName)
        {
            SymbolName = symbolName;
            Type = type;
            Depth = depth;
            ScopeName = scopeName;
        }

        public string ScopeName { get; } 
        public string SymbolName { get; }
        public TypeInfo Type { get; }
        public int Depth { get; }


        public override string ToString()
        {
            return $"{SymbolName} declared in: {ScopeName}, at depth: {Depth}";
        }
    }
}
