using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class TypeInfo
    {
        public IToken Type { get; }
        public TypeInfo(IToken type)
        {
            Type = type;
        }

    }
}
