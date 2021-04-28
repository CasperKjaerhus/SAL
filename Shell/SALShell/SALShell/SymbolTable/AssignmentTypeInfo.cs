using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        bool isReference { get; }
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
                return $"Assignment is of type {Type.Text}";
        }



    }

}
