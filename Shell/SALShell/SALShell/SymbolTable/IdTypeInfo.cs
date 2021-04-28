using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class IdTypeInfo : TypeInfo
    {
        public IdTypeInfo(IToken idName, IToken arraySize, IToken type):base(type)
        {
            this.idName = idName;
            this.arraySize = arraySize;
        }

        IToken idName { get; }
        IToken arraySize { get; }

        public override string ToString()
        {
            if (Type == null)
                return $"Id Reference with name {idName.Text}";
            else
                return $"Id name {idName.Text} with type {Type.Text}";
        }
    }
}
