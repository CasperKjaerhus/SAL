using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class Symbol
    {
        public Symbol(string symbolName, TypeInfo type, List<Symbol> level, int depth, string scopename)
        {
            SymbolName = symbolName;
            Type = type;
            Level = level;
            Depth = depth;
            scopeName = scopename;
        }

        public Symbol(Symbol var, List<Symbol> level)
        {
            Var = var;
            Level = level;
        }

        public Symbol()
        {
        }

        public string scopeName { get; } 
        public string SymbolName { get; }
        public TypeInfo Type { get; }
        public Symbol Var { get; set; }
        public List<Symbol> Level { get; set; }
        public int Depth { get; }
        public int HashCode { get; } 

        public override string ToString()
        {
            return $"{SymbolName} declared in: {scopeName}, at depth: {Depth}";
        }
    }
}
