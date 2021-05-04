using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymTable : ISymbolTable<Symbol, TypeInfo>
    {

        //THIS SYMBOL TABLE PROBABLY HAVE A VERY BAD SPACE AND TIME COMPLEXITY BUT ¯\_(ツ)_/¯
        private int Depth = 0;
        private int scopeindex = 0;
        private Scope ParentScope = new Scope(null, "global", 0);
        public List<Scope> ScopeDisplay { private set; get; }

        public SymTable()
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

        // Creates a new symbol with a given name, and the relevant typeinfo (only declarations)
        // Checks for references if there is a declaration, if not, do something about it.
        // Else if a symbol is declared in the same scope call error.
        public Symbol EnterSymbol(string name, TypeInfo typeinf)
        {
            Symbol newSym = null;

            switch (typeinf)
            {
                case IdTypeInfo idRef:
                    newSym = ReferenceExists(name, idRef);
                    break;
                case AssignmentTypeInfo asmnRef:
                    newSym = ReferenceExists(name, asmnRef);
                    break;
                default:
                    if(!DeclaredInScope(name, ScopeDisplay[scopeindex].scopeName))
                    {
                        newSym = new Symbol(name, typeinf, Depth, ScopeDisplay[scopeindex].scopeName);
                        ScopeDisplay[scopeindex].symbols.Add(newSym);
                        return newSym;
                    }
                    break;
            }

            if (newSym != null)
            {
                ScopeDisplay[scopeindex].symbols.Add(newSym);
            }

            return newSym;
        }

        //Checks if reference for variable exists
        private Symbol ReferenceExists(string name, IdTypeInfo idRef)
        {
            if (!idRef.IsReference)
                return new Symbol(name, idRef, Depth, ScopeDisplay[scopeindex].scopeName);

            Scope scope = ScopeDisplay[scopeindex];

            while(!(scope.symbols.Any(x => x.SymbolName == name)))
            {
                if (scope == null)
                {
                    Console.WriteLine($"Symbol reference not found {name}");
                    return null;
                }
                scope = scope.Parent;
            }

            Console.WriteLine($"Symbol reference found {name}");
            return null;
        }

        //Checks if reference for variable assignment exists
        private Symbol ReferenceExists(string name, AssignmentTypeInfo asmnRef)
        {
            if (!asmnRef.IsReference)
                return new Symbol(name, asmnRef, Depth, ScopeDisplay[scopeindex].scopeName);

            Scope scope = ScopeDisplay[scopeindex];

            while (!(scope.symbols.Any(x => x.SymbolName == name)))
            {
                scope = scope.Parent;
                if (scope == null)
                {
                    Console.WriteLine($"Symbol reference not found {name}");
                    return null;
                }
            }

            Console.WriteLine($"Symbol reference found {name}");
            return null;
        }

        //Checks if all function calls can be made, if all functions are declared in global
        public void CheckFunctionReferences()
        {
            List<Symbol> functions = new List<Symbol>();
            List<Symbol> failedReferences = new List<Symbol>();

            functions.AddRange(ScopeDisplay[0].symbols.Where(x => x.Type is FuncTypeInfo).ToList());

            foreach (Scope scope in ScopeDisplay)
            {
                foreach(Symbol sym in scope.symbols.Where(x => x.Type is FuncCallTypeInfo).ToList())
                {
                    if (!(functions.Any(x => x.SymbolName == sym.SymbolName)))
                    {
                        Console.WriteLine($"No such function {sym.SymbolName}");
                        failedReferences.Add(sym);
                    }
                }
                scope.symbols.RemoveAll(x => x.Type is FuncCallTypeInfo);
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
