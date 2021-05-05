using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class DeclTypeInfo : TypeInfo
    {
        public IToken ArraySize { get; }
        public DeclTypeInfo(IToken type) : base(type)
        {
        }
        public DeclTypeInfo(IToken type, IToken arraysize) : base(type)
        {
            this.ArraySize = arraysize;
        }

        public override string ToString()
        {
            return $"Declaration is of {Type.Text}";
        }
    }
}
