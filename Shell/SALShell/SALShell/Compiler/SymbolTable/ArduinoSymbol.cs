using SALShell.Compiler.Parser;

namespace SALShell.Compiler.SymbolTable
{
    internal class ArduinoSymbol
    {
        public string Name { get; set; }
        public SALTypeEnum SALType { get; set; }
        public InoTypeEnum InoType { get; set; }
        public SALTypeEnum[] ParameterTypes { get; set; }
    }
}
