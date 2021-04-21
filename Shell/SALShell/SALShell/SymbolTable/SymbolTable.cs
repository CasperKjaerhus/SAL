using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymbolTable : ISymbolTable<Symbol>
    {
        private int Depth = 0;
        private List<List<Symbol>> ScopeDisplay = new List<List<Symbol>>();
        private Dictionary<string, Symbol> Table = new Dictionary<string, Symbol>();
        private List<Symbol> RemovedSymbols = new List<Symbol>();
        private Symbol prevSym = new Symbol();

        public void OpenScope()
        {
            Depth++;
            ScopeDisplay[Depth] = null;
        }
        public void CloseScope()
        {
            foreach (Symbol sym in ScopeDisplay[Depth])
            {
                prevSym = sym.Var;
                DeleteSym(sym);
                if (prevSym != null)
                    Table.Add(prevSym.SymbolName, prevSym);
            }
            Depth--;
        }

        public void EnterSymbol(string name, Symbol symbol)
        {
            Table.Add(name, symbol);
        }

        public List<Symbol> RetrieveSymbol(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeclaredLocally(string name)
        {
            throw new NotImplementedException();
        }


        private void DeleteSym(Symbol sym)
        {
            Symbol removedSym;
            Table.Remove(sym.SymbolName, out removedSym);

            RemovedSymbols.Add(new Symbol(removedSym.Var, removedSym.Level));
        }
    }
}
