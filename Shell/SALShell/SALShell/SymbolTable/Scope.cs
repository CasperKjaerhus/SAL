using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class Scope
    {
        public Scope(Scope parent, string scopeName)
        {
            Parent = parent;
            this.scopeName = scopeName;
            symbols = new List<Symbol>();
        }

        public Scope Parent { get; set; }
        public string scopeName { get; }
        public List<Symbol> symbols { get; set; }
    }
}
