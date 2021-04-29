using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    interface ISymbolTable<T, K, S>
    {
        public void OpenScope(string scopename);
        public void CloseScope();
        public void EnterSymbol(string name, K typeinfo);
        public bool DeclaredLocally(string name, string scopename);
        public List<S> GetScopes();
    }
}
