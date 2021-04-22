using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    interface ISymbolTable<T, K>
    {
        public void OpenScope();
        public void CloseScope();
        public void EnterSymbol(string name, K typeinfo);
        public T RetrieveSymbol(string name);
        public bool DeclaredLocally(string name);
    }
}
