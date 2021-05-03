using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class IdTypeInfo : TypeInfo
    {
        public bool isArray { get; }
        public bool isReference { get; }
        public IdTypeInfo(IToken arraySize, IToken type):base(type)
        {
            this.arraySize = arraySize;
            if (arraySize == null)
                isArray = false;
            else
                isArray = true;

            if (type == null)
                isReference = true;
            else
                isReference = false;
        }

        IToken idName { get; }
        IToken arraySize { get; }

        public override string ToString()
        {
            if (isReference)
                return $"Id is reference";
            else
                return $"Id type {Type.Text}";
        }
    }
}
