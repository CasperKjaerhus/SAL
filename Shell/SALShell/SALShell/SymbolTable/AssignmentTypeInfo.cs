using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class AssignmentTypeInfo : TypeInfo
    {
        IToken id { get; }
        IToken assigment { get; }
        
    }
}
