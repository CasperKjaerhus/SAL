using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymbolTableActual : ISymbolTable<Symbol, TypeInfo, Scope>
    {

        //THIS SYMBOL TABLE PROBABLY HAVE A VERY BAD SPACE AND TIME COMPLEXITY BUT ¯\_(ツ)_/¯
        private int Depth = 0;
        private int scopeindex = 0;
        private Scope ParentScope = new Scope(null, "global", 0);
        private List<Scope> ScopeDisplay = new List<Scope>();
        private Dictionary<string, Symbol> Table = new Dictionary<string, Symbol>();
        private List<Symbol> RemovedSymbols = new List<Symbol>();

        public SymbolTableActual()
        {
            ScopeDisplay.Add(ParentScope);
        }

        // Counts up depth, and sets clears indexed list (the higher the depth, the inner the scope)
        public void OpenScope(string scopeName)
        {
            if (Depth == 0)
            {
                ParentScope = ScopeDisplay[0];
            }
            else
                ParentScope = ScopeDisplay.FindLast(x => x.Depth == Depth - 1);
            Scope NewScope = new Scope(ParentScope, scopeName, Depth);
            ScopeDisplay.Add(NewScope);
            scopeindex = ScopeDisplay.FindIndex(x => x.scopeName == scopeName);
            Depth++;
        }

        // Counts up depth, and sets clears indexed list (the higher the depth, the inner the scope)
        public void CloseScope()
        {
            foreach (Symbol sym in ScopeDisplay[scopeindex].symbols)     
            {
                Symbol prevSym = sym.Var;
                DeleteSym(sym);
                if(prevSym != null)
                {
                    Table.Add(prevSym.SymbolName, sym);
                }
            }
            Depth--;
            string scopeParent = ScopeDisplay[scopeindex].Parent.scopeName;
            scopeindex = ScopeDisplay.FindIndex(x => x.scopeName == scopeParent);

        }

        // Creates a new symbol with a given name, and the relevant typeinfo
        // If no previous instance of a symbol with the same name exists, add the symbol to the table.
        // Else if a symbol is declared in the same scope call error, or else set the "Var" of the symbol to previous symbol.
        public void EnterSymbol(string name, TypeInfo typeinf)
        {
            Symbol oldSym = RetrieveSymbol(name);

            if ((oldSym != null && oldSym.Depth == Depth) && oldSym.Type.GetType() == typeinf.GetType())
            {
                Console.WriteLine("duplicate? " + $"{oldSym.SymbolName}");
            }

            Symbol newSym = new Symbol(name, typeinf, ScopeDisplay[scopeindex].symbols, Depth, ScopeDisplay[scopeindex].scopeName);

            ScopeDisplay[scopeindex].symbols.Add(newSym);

            if(oldSym == null)
                Table.Add(newSym.SymbolName, newSym);
            else
            {
                newSym.Var = oldSym;
                DeleteSym(oldSym);
            }
        }

        //Gets the symbol out of the table according to name.
        private Symbol RetrieveSymbol(string name)
        {
            if (Table.ContainsKey(name))
                return Table[name];
            else
                return null;
        }

        //Returns true if their exists a symbol with the name, in the given scope, else false.
        public bool DeclaredLocally(string symbolName, string ScopeName)
        {
            return ScopeDisplay[ScopeDisplay.FindIndex(x => x.scopeName == ScopeName)].symbols.Any(x => x.SymbolName == symbolName);
        }

        //Deletes the symbols from the dictionary, and adds them to a list of removed symbols.
        private void DeleteSym(Symbol sym)
        {
            Symbol removedSym;
            Table.Remove(sym.SymbolName, out removedSym);
            RemovedSymbols.Add(removedSym);
        }
        
        public void PrintSymbols()
        {
            foreach (Scope scope in ScopeDisplay)
            {
                if(scope.Parent != null)
                    Console.WriteLine($"In scope: {scope.scopeName}, parent: {scope.Parent.scopeName}");
                else
                    Console.WriteLine($"In scope: {scope.scopeName}");
                foreach (Symbol sym in scope.symbols)
                {
                    Console.WriteLine(sym + $"\t\t\t {sym.Type}");
                }
            }
        }

        public List<Scope> GetScopes()
        {
            return ScopeDisplay;
        }

        public List<Symbol> RetrieveSymbols(string Name)
        {
            List<Symbol> symbols = new List<Symbol>();
            foreach (Scope scope in ScopeDisplay)
            {
                symbols.AddRange(scope.symbols.FindAll(x => x.SymbolName == Name));
            }

            return symbols;
        }

    }
}
