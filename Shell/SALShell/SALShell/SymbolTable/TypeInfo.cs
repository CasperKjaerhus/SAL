using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    abstract class TypeInfo
    {
        protected TypeInfo(IToken type)
        {
            Type = type;
        }

        IToken Type { get; }

    }
}
