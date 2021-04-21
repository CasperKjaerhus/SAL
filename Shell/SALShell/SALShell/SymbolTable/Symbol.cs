using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class Symbol
    {
        public Symbol(string symbolName, string type, Symbol var, int level, int depth)
        {
            SymbolName = symbolName;
            Type = type;
            Var = var;
            Level = level;
            Depth = depth;
            Hash = GetHashCode();
        }
        public Symbol(Symbol var, int level)
        {
            Var = var;
            Level = level;
            Hash = GetHashCode();
        }

        public Symbol()
        {
        }

        public string SymbolName { get; }
        public string Type { get; }
        public Symbol Var { get; }
        public int Level { get; }
        public int Depth { get; }
        public int Hash { get; } 

        public override bool Equals(object obj)
        {
            return obj is Symbol symbol &&
                   SymbolName == symbol.SymbolName &&
                   Type == symbol.Type &&
                   EqualityComparer<Symbol>.Default.Equals(Var, symbol.Var) &&
                   Level == symbol.Level &&
                   Depth == symbol.Depth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SymbolName, Type, Var, Level, Depth);
        }
    }
}
