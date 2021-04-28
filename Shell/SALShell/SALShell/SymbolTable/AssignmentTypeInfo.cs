using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        bool isReference { get; }
        public AssignmentTypeInfo(IToken id, IToken type):base(type)
        {
            this.id = id;
            if (type == null)
                isReference = true;
            else
                isReference = false;
        }

        public IToken id { get; }
        public override string ToString()
        {
            if (isReference)
                return $"Variable reference";
            else
                return $"Assignment is of type {Type.Text}, with name {id.Text}";
        }



    }

}
