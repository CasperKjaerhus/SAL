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

        public override string ToString()
        {
            string funcString = "Function declaration taking the paremeters: ";
            foreach (IToken parameter in parameters)
            {
                funcString += parameter.Text + " ";
            }
            return funcString;
        }
    }
}
