using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class FuncCallTypeInfo : TypeInfo
    {
        public FuncCallTypeInfo(IToken type) : base(type)
        {
        }

        public override string ToString()
        {
            return $"Function Reference";
        }
    }
}
