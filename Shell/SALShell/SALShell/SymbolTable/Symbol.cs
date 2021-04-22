﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class Symbol
    {
        public Symbol(string symbolName, TypeInfo type, List<Symbol> level, int depth)
        {
            SymbolName = symbolName;
            Type = type;
            Level = level;
            Depth = depth;
            HashCode = GetHashCode();
        }
        public Symbol(Symbol var, List<Symbol> level)
        {
            Var = var;
            Level = level;
            HashCode = GetHashCode();
        }

        public Symbol()
        {
        }

        public string SymbolName { get; }
        public TypeInfo Type { get; }
        public Symbol Var { get; set; }
        public List<Symbol> Level { get; set; }
        public int Depth { get; }
        public Symbol Hash { get; }
        public int HashCode { get; } 

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
            return System.HashCode.Combine(SymbolName, Type, Var, Level, Depth);
        }
    }
}
