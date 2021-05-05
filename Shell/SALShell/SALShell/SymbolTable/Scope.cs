using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class Scope
    {
        public int Depth { get; }
        public Scope Parent { get; set; }
        public string ScopeName { get; }
        public List<Symbol> Symbols { get; set; }

        public Scope(Scope parent, string scopeName, int depth)
        {
            this.Parent = parent;
            this.ScopeName = scopeName;
            this.Symbols = new List<Symbol>();
            this.Depth = depth; 
        }
    }
}
