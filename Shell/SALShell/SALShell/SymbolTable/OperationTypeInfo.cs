using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class OperationTypeInfo : TypeInfo
    {
        public OperationTypeInfo(TypeInfo numberOne, TypeInfo numberTwo, IToken token):base(token)
        {
            this.numberOne = numberOne;
            this.numberTwo = numberTwo;
        }

        public TypeInfo numberOne { get; }
        public TypeInfo numberTwo { get; }
    }
}
