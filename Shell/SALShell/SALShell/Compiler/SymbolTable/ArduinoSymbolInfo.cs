using SALShell.Compiler.Parser;

namespace SALShell.Compiler.SymbolTable
{
    internal class ArduinoSymbolInfo
    {
        public string Name { get; set; }
        public SALTypeEnum SALType { get; set; }
        public InoTypeEnum InoType { get; set; }
        public ArduinoParameter[] ParameterTypes { get; set; }
    }
}
