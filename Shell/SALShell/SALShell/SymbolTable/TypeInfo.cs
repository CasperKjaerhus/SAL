using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    public abstract class TypeInfo
    {
        public IToken Type { get; }
        public TypeInfo(IToken type)
        {
            Type = type;
        }

    }
}
