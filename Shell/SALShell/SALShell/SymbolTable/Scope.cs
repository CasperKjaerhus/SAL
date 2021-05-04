using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class Scope
    {
        public int Depth { get; }
        public Scope Parent { get; set; }
        public string scopeName { get; }
        public List<Symbol> symbols { get; set; }

        public Scope(Scope parent, string scopeName, int depth)
        {
            this.Parent = parent;
            this.scopeName = scopeName;
            this.symbols = new List<Symbol>();
            this.Depth = depth; 
        }
    }
}
