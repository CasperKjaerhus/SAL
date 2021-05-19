using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{

    public class Symbol
    {

        public string Name { get; }
        public SALTypeEnum Type { get; }
        public Scope Scope { get; }

        public Symbol(Scope scope, string name, SALTypeEnum type)
        {
            Name = name;
            Type = type;
            Scope = scope;
        }

        public override string ToString()
        {
            return $"Symbol {Name}: Depth {Scope.Depth} Type {Type}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Symbol item)
            {
                return item.Scope.Depth == this.Scope.Depth && item.Name == this.Name && item.Type == this.Type;
            }

            return false;
        }

    }
}
