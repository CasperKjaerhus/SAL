using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    interface ISymbolTable<T, K> //T should be some Symbol class and K should be some Type Information class
    {
        public void OpenScope(string scopename);
        public void CloseScope();
        public T EnterSymbol(string name, K typeinfo);
        public bool DeclaredInScope(string symname, string scopename);
        public List<T> RetrieveSymbols(string name);
        public Symbol RetrieveFunction(string FuncName);
    }
}
