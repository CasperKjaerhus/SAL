using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class DeclTypeInfo : TypeInfo
    {
        IToken arraySize { get; }
        public DeclTypeInfo(IToken type) : base(type)
        {
        }
        public DeclTypeInfo(IToken type, IToken arraysize) : base(type)
        {
            this.arraySize = arraysize;
        }

        public override string ToString()
        {
            return $"Declaration is of {Type.Text}";
        }
    }
}
