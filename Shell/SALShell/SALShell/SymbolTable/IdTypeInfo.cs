using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class IdTypeInfo : TypeInfo
    {
        public bool IsArray { get; }
        public bool IsReference { get; }
        public IToken IdName { get; }
        public bool IsAssignment { get; set; }
        public int ArraySize { get; }

        public IdTypeInfo(IToken arraySize, IToken type):base(type)
        {
            if (arraySize == null)
                IsArray = false;
            else
            {
                this.ArraySize = Convert.ToInt32(arraySize.Text);
            }

            if (type == null)
                IsReference = true;
            else
                IsReference = false;
        }
        public override string ToString()
        {
            if (IsReference)
                return $"Id is reference";
            else
                return $"Id type {Type}";
        }
    }
}
