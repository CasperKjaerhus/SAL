using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    interface ISymbolTable<T, K>
    {
        public void OpenScope(string scopename);
        public void CloseScope();
        public void EnterSymbol(string name, K typeinfo);
        public bool DeclaredInScope(string symname, string scopename);
    }
}
