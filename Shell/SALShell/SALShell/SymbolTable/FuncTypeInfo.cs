using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class FuncTypeInfo : TypeInfo
    {
        List<IToken> parameters = new List<IToken>();

        public FuncTypeInfo(IToken type, List<IToken> tokens) : base(type)
        {
            parameters = tokens;
        }
    }
}
