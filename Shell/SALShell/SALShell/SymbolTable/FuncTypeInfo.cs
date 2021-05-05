using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class FuncTypeInfo : TypeInfo
    {
        public List<IToken> Parameters { get; }

        public FuncTypeInfo(IToken type, List<IToken> tokens) : base(type)
        {
            Parameters = tokens;
        }

        public override string ToString()
        {
            string funcString = "Function declaration taking the parameters: ";
            foreach (IToken parameter in Parameters)
            {
                funcString += parameter.Text + " ";
            }
            return funcString;
        }
    }
}
