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

        public IToken id { get; }
        public TypeInfo assigment { get; }
        public override string ToString()
        {
            return $"Assignment is of type {Type.Text}, with name {id.Text} and assignment is: {assigment}";
        }



    }

}
