using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymbolTableActual : ISymbolTable<Symbol, TypeInfo>
    {

        //THIS SYMBOL TABLE PROBABLY HAVE A VERY BAD SPACE AND TIME COMPLEXITY BUT ¯\_(ツ)_/¯
        private int Depth = 0;
        private int scopeindex = 0;
        private Scope ParentScope = new Scope(null, "global", 0);
        public List<Scope> ScopeDisplay { private set; get; }

        public SymbolTableActual()
        {
            ScopeDisplay = new List<Scope>();
            ScopeDisplay.Add(ParentScope);
        }

        // Counts up depth, and creates a new scope, and changes the scope index to the current scope. 
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

        //Counts down the depth, and change the scope index to be the parent of the previous scope
        public void CloseScope()
        {
            Depth--;
            string scopeParent = ScopeDisplay[scopeindex].Parent.scopeName;
            scopeindex = ScopeDisplay.FindIndex(x => x.scopeName == scopeParent);
        }

        // Creates a new symbol with a given name, and the relevant typeinfo
        // If no previous instance of a symbol with the same name exists, add the symbol to the table.
        // Else if a symbol is declared in the same scope call error, or else set the "Var" of the symbol to previous symbol.
        public Symbol EnterSymbol(string name, TypeInfo typeinf)
        {
            Symbol newSym = null;

            switch (typeinf)
            {
                case IdTypeInfo idRef:
                    ReferenceExists(name, idRef);
                    break;
                case AssignmentTypeInfo asmnRef:
                    ReferenceExists(name, asmnRef);
                    break;
                default:
                    newSym = new Symbol(name, typeinf, ScopeDisplay[scopeindex].symbols, Depth, ScopeDisplay[scopeindex].scopeName);
                    ScopeDisplay[scopeindex].symbols.Add(newSym);
                    break;
            }

            return newSym;
        }

        //Checks if reference for variable exists
        private void ReferenceExists(string name, IdTypeInfo idRef)
        {
            if (!idRef.isReference)
                return;

            Scope scope = ScopeDisplay[scopeindex];

            while(!(scope.symbols.Any(x => x.SymbolName == name)))
            {
                if (scope == null)
                {
                    Console.WriteLine($"Symbol reference not found {name}");
                    return;
                }
                scope = scope.Parent;
            }

            Console.WriteLine($"Symbol reference found {name}");
        }

        //Checks if reference for variable assignment exists
        private void ReferenceExists(string name, AssignmentTypeInfo asmnRef)
        {
            if (!asmnRef.isReference)
                return;

            Scope scope = ScopeDisplay[scopeindex];

            while (!(scope.symbols.Any(x => x.SymbolName == name)))
            {
                scope = scope.Parent;
                if (scope == null)
                {
                    Console.WriteLine($"Symbol reference not found {name}");
                    return;
                }
            }

            Console.WriteLine($"Symbol reference found {name}");
        }

        //Checks if all function calls can be made, if all functions are declared in global
        public void CheckFunctionReferences()
        {
            List<Symbol> functions = new List<Symbol>();
            functions.AddRange(ScopeDisplay[0].symbols.Where(x => x.Type is FuncTypeInfo).ToList());

            foreach (Scope scope in ScopeDisplay)
            {
                foreach(Symbol sym in scope.symbols.Where(x => x.Type is FuncCallTypeInfo).ToList())
                {
                    if (!(functions.Any(x => x.SymbolName == sym.SymbolName)))
                        Console.WriteLine($"No such function {sym.SymbolName}");
                }
            }
        }

        //Returns true if their exists a symbol with the name in the scope, in the given scope, else false.
        public bool DeclaredInScope(string symbolName, string ScopeName)
        {
            return ScopeDisplay[ScopeDisplay.FindIndex(x => x.scopeName == ScopeName)].symbols.Any(x => x.SymbolName == symbolName);
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

        //Gets a list of the symbols with the given name.
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
