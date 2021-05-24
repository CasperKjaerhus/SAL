using SALShell.Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.Compiler.SymbolTable
{
    class ArduinoParameter
    {
        public string Name { get; set; }
        public SALTypeEnum Type { get; set; }
    }
}
