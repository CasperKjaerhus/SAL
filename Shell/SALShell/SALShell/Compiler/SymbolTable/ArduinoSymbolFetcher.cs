using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace SALShell.Compiler.SymbolTable
{
    public class ArduinoSymbolFetcher
    {
        public ArduinoSymbolFetcher()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                Stream stream = assembly.GetManifestResourceStream("SALShell.SymbolTable.ArduinoSymbols.json");
                StreamReader reader = new StreamReader(stream);

                string result = reader.ReadToEnd();

                ArduinoSymbol[] symbols = JsonSerializer.Deserialize<ArduinoSymbol[]>(result);
            }
            catch (Exception e)
            {
                // TODO: Error Handling in case file could not be found/read idk why
                throw e;
            }
            

            
        }

    }
}