using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    interface ISymbolTable<T>
    {
        public void OpenScope();
        public void CloseScope();
        public void EnterSymbol(string name, T symbol);
        public List<T> RetrieveSymbol(string name);
        public bool DeclaredLocally(string name);
    }
}
