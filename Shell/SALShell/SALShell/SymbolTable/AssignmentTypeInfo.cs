using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        public bool isReference { get; }
        public AssignmentTypeInfo(IToken type):base(type)
        {
            if (type == null)
                isReference = true;
            else
                isReference = false;
        }

        public override string ToString()
        {
            if (isReference)
                return $"Variable reference";
            else
                return $"Initialisation is of type {Type}";
        }



    }

}
