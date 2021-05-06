using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SALShell.SymbolTable
{
    class SymTable : ISymbolTable<Symbol, TypeInfo>
    {

        private int Depth = 0;
        private int scopeindex = 0; //THE SCOPE INDEX KEEPS TRACK OF THE CURRENT SCOPE, IS USED FOR ACCESSING THE INDEX IN SCOPEDISPLAY LIST                 
        private Scope ParentScope = new Scope(null, "Global", 0);
        public List<Scope> ScopeList { private set; get; }

        public SymTable()
        {
            ScopeList = new List<Scope>();
            ScopeList.Add(ParentScope);      //Whenever the symbol table is constructed, set the first scope in the list to be "global"
        }

        // Counts up depth, and creates a new scope, and changes the scope index to the current scope.
        // The higher the depth, the inner the scope!
        public void OpenScope(string scopeName)
        {
            if (Depth == 0)
            {
                ParentScope = ScopeList[0]; //If the current depth is 0, it means we're in the global scope and therefore the parentscope shall be global
            }
            else
                ParentScope = ScopeList.FindLast(x => x.Depth == Depth - 1); //As the list is unordered, it finds the last indexed scope with one lesser depth than the current depth.

            Scope NewScope = new Scope(ParentScope, scopeName, Depth);
            ScopeList.Add(NewScope);
            scopeindex = ScopeList.Count - 1;                                //Sets the current scopeindex to the newly added scope (The last added in the list)
            Depth++;
        }

        //Counts down the depth, and change the scope index to be the parent of the previous scope
        public void CloseScope()
        {
            Depth--;
            string scopeParent = ScopeList[scopeindex].Parent.ScopeName;
            scopeindex = ScopeList.FindIndex(x => x.ScopeName == scopeParent); //Sets the current scope index to the currents scope's parent
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
                    if(!DeclaredInScope(name, ScopeList[scopeindex].ScopeName))
                    {
                        newSym = new Symbol(name, typeinf, Depth, ScopeList[scopeindex].ScopeName);
                        ScopeList[scopeindex].Symbols.Add(newSym);
                        return newSym;
                    }
                    break;
            }

            if (newSym != null)
            {
                ScopeList[scopeindex].Symbols.Add(newSym);
            }

            return newSym;
        }

        //Checks if reference for variable exists
        private Symbol ReferenceExists(string name, IdTypeInfo idRef)
        {
            if (!idRef.IsReference)
                return new Symbol(name, idRef, Depth, ScopeList[scopeindex].ScopeName);

            Scope scope = ScopeList[scopeindex];

            while(!(scope.Symbols.Any(x => x.SymbolName == name)))
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

        //Checks if reference for variable assignment exists
        private Symbol ReferenceExists(string name, AssignmentTypeInfo asmnRef)
        {
            if (!asmnRef.IsReference)
                return new Symbol(name, asmnRef, Depth, ScopeList[scopeindex].ScopeName);

            Scope scope = ScopeList[scopeindex];

            while (!(scope.Symbols.Any(x => x.SymbolName == name)))
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

        //Checks if all function calls can be made and that all functions are declared in global
        //Adds all the failed function references to a list, which should be used for error-handling
        public void CheckFunctionReferences()
        {
            List<Symbol> functions = new List<Symbol>();
            List<Symbol> failedReferences = new List<Symbol>();

            functions.AddRange(ScopeList[0].Symbols.Where(x => x.Type is FuncTypeInfo).ToList());

            foreach (Scope scope in ScopeList)
            {
                foreach(Symbol sym in scope.Symbols.Where(x => x.Type is FuncCallTypeInfo).ToList())
                {
                    if (!(functions.Any(x => x.SymbolName == sym.SymbolName)))
                    {
                        Console.WriteLine($"No such function {sym.SymbolName}");
                        failedReferences.Add(sym);
                    }
                }
                scope.Symbols.RemoveAll(x => x.Type is FuncCallTypeInfo);
            }

        }

        //Returns true if their exists a symbol with the name in the scope, in the given scope, else false.
        public bool DeclaredInScope(string symbolName, string ScopeName)
        {
            return ScopeList.Find(x => x.ScopeName == ScopeName).Symbols.Any(x => x.SymbolName == symbolName);
        }
        
        public void PrintSymbols()
        {
            foreach (Scope scope in ScopeList)
            {
                if(scope.Parent != null)
                    Console.WriteLine($"In scope: {scope.ScopeName}, parent: {scope.Parent.ScopeName}");
                else
                    Console.WriteLine($"In scope: {scope.ScopeName}");
                foreach (Symbol sym in scope.Symbols)
                {
                    Console.WriteLine(sym + $"\t\t\t {sym.Type}");
                }
            }
        }

        //Gets a list of the symbols with the given name.
        public List<Symbol> RetrieveSymbols(string Name)
        {
            List<Symbol> symbols = new List<Symbol>();
            foreach (Scope scope in ScopeList)
            {
                symbols.AddRange(scope.Symbols.FindAll(x => x.SymbolName == Name));
            }
            return symbols;
        }

        public Symbol RetrieveFunction(string FuncName)
        {
            return ScopeList[0].Symbols.Find(x => x.SymbolName == FuncName && x.Type is FuncTypeInfo);
        }

    }
}
