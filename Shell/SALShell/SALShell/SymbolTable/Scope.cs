using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALShell.SymbolTable
{
    public class Scope
    {
        public int Depth { get; }
        public Scope Parent { get; set; }
        public string ScopeName { get; }
        public List<Symbol> Symbols { get; set; }
        public SALTypeEnum ReturnType { 
            get 
            {
                if(_returnType == SALTypeEnum.undefined)
                {
                    return Parent.ReturnType;
                }
                return _returnType;
            }
            set
            {
                _returnType = value;
            }
        }
        private SALTypeEnum _returnType { get; set; } = SALTypeEnum.undefined;

        public Scope(Scope parent, int depth)
        {
            this.Parent = parent;
            this.Symbols = new List<Symbol>();
            this.Depth = depth;
        }

        public bool IsSymbolWithinScope(Symbol symbol)
        {
            foreach(Symbol s in Symbols)
            {
                if (s.Equals(symbol))
                    return true;
            }

            if (Parent != null)
                return Parent.IsSymbolWithinScope(symbol);

            return false;
        }
        public Symbol RetrieveSymbol(string IdName)
        {
            foreach(Symbol s in Symbols)
            {
                if(s.Name == IdName)
                {
                    return s;
                }
            }
            if (Parent != null)
                return Parent.RetrieveSymbol(IdName);

            return null;
        }

        public Symbol this[string idName] => RetrieveSymbol(idName);

        public void Print()
        {
            Console.WriteLine($"Scope @ depth {Depth} containing symbols: ");
            foreach(Symbol symbol in Symbols)
            {
                Console.WriteLine(symbol);
            }
        }
    }
}
