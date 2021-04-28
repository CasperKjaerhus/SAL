using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class TypeInfo
    {
        public TypeInfo(IToken type)
        {
            Type = type;
        }

        public IToken Type { get; }

    }
}
