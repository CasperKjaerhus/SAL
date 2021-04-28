using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class OperationTypeInfo : TypeInfo
    {
        public OperationTypeInfo(TypeInfo numberOne, TypeInfo numberTwo, IToken operation) : base(operation)
        {
            this.numberOne = numberOne;
            this.numberTwo = numberTwo;
        }

        public TypeInfo numberOne { get; }
        public TypeInfo numberTwo { get; }

        public override string ToString()
        {
            return $"{numberOne} {Type.Text} {numberTwo}";
        }
    }
}
