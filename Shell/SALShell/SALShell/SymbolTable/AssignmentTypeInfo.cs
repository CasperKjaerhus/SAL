using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        public bool IsReference { get; }
        public AssignmentTypeInfo(IToken type):base(type)
        {
            if (type == null)
                IsReference = true;
            else
                IsReference = false;
        }

        public override string ToString()
        {
            if (IsReference)
                return $"Variable reference";
            else
                return $"Initialisation is of type {Type.Text}";
        }



    }

}
