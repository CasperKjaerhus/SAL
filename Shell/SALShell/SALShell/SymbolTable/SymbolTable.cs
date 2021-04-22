using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymbolTable : ISymbolTable<Symbol, TypeInfo>
    {

        //THIS SYMBOL TABLE PROBABLY HAVE A VERY BAD SPACE AND TIME COMPLEXITY BUT ¯\_(ツ)_/¯
        private int Depth = 0;
        private List<List<Symbol>> ScopeDisplay = new List<List<Symbol>>();
        private Dictionary<string, Symbol> Table = new Dictionary<string, Symbol>();
        private List<Symbol> RemovedSymbols = new List<Symbol>();

        // Counts up depth, and sets clears indexed list (the higher the depth, the inner the scope)
        public void OpenScope()
        {
            Depth++;
            ScopeDisplay[Depth].Clear();
        }
        // Counts up depth, and sets clears indexed list (the higher the depth, the inner the scope)
        public void CloseScope()
        {
            foreach (Symbol sym in ScopeDisplay[Depth])     
            {
                Symbol prevSym = sym.Var;
                DeleteSym(sym);
                if(prevSym != null)
                {
                    Table.Add(prevSym.SymbolName, sym);
                }
            }
            Depth--;
        }

        // Creates a new symbol with a given name, and the relevant typeinfo
        // If no previous instance of a symbol with the same name exists, add the symbol to the table.
        // Else if a symbol is declared in the same scope call error, or else set the "Var" of the symbol to previous symbol.
        public void EnterSymbol(string name, TypeInfo typeinf)
        {
            Symbol oldSym = RetrieveSymbol(name);

            if (oldSym != null && oldSym.Depth == Depth){
                throw new ArgumentException($"Duplicate definition of {name}");
            }

            Symbol newSym = new Symbol(name, typeinf, ScopeDisplay[Depth], Depth);
            ScopeDisplay[Depth].Add(newSym);

            if(oldSym == null)
                Table.Add(newSym.SymbolName, newSym);
            else
            {
                newSym.Var = oldSym;
                DeleteSym(oldSym);
            }
        }

        //Gets the symbol out of the table according to name.
        public Symbol RetrieveSymbol(string name)
        {
            if (Table[name] != null)
                return Table[name];
            else
                return null;
        }

        //Returns true if their exists a symbol with the name, in the given scope, else false.
        public bool DeclaredLocally(string name)
        {
            return ScopeDisplay[Depth].Any(x => x.SymbolName == name);
        }

        //Deletes the symbols from the dictionary, and adds them to a list of removed symbols.
        private void DeleteSym(Symbol sym)
        {
            Symbol removedSym;
            Table.Remove(sym.SymbolName, out removedSym);
            RemovedSymbols.Add(new Symbol(removedSym.Var, removedSym.Level));
        }
    }
}
