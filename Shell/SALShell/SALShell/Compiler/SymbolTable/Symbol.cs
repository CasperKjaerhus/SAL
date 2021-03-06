using System;
using SALShell.Compiler.Parser;

namespace SALShell.Compiler.SymbolTable
{

    public class Symbol
    {

        public string Name { get; }
        public SALTypeEnum Type { get; }
        public Scope Scope { get; }

        public bool IsExtern { get; set; } = false;

        public Symbol(Scope scope, string name, SALTypeEnum type)
        {
            Name = name;
            Type = type;
            Scope = scope;
        }

        public Symbol(Scope scope, string name, SALTypeEnum type, bool isExtern) : this(scope, name, type)
        {
            IsExtern = isExtern;
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
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Scope);
        }
    }
}
