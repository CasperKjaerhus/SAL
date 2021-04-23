using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        public AssignmentTypeInfo(IToken id, TypeInfo assigment, IToken type):base(type)
        {
            this.id = id;
            this.assigment = assigment;
        }

        IToken id { get; }
        TypeInfo assigment { get; }
        
    }
}
