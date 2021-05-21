using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    internal class ArduinoSymbol
    {
        public string Name { get; set; }
        public SALTypeEnum SALType { get; set; }
        public InoTypeEnum InoType { get; set; }
        public SALTypeEnum[] ParameterTypes { get; set; }
    }
}
