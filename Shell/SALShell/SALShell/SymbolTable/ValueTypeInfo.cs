using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class ValueTypeInfo : TypeInfo
    {
        public ValueTypeInfo(IToken token):base(token)
        {
        }
    }
}
