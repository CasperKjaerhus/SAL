using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SALShell.Compiler.SymbolTable
{
    internal class ArduinoSymbolFetcher
    {
        private ArduinoSymbolInfo[] Symbols { get; }
        public ArduinoSymbolFetcher()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                Stream stream = assembly.GetManifestResourceStream("SALShell.Compiler.SymbolTable.ArduinoSymbols.json");
                StreamReader reader = new StreamReader(stream);
                var options = new JsonSerializerOptions
                {
                    Converters =
                    {
                        new JsonStringEnumConverter()
                    }
                };

                string result = reader.ReadToEnd();

                Symbols = JsonSerializer.Deserialize<ArduinoSymbolInfo[]>(result, options);
            }
            catch (JsonException e)
            {
                Console.WriteLine("ERROR: Bad JSON in ArduinoSymbols.json, could not load arduino constants! Aborting Compilation.");
                throw e;
            }
            catch(Exception e)
            {
                // TODO: Error Handling in case file could not be found/read/bad json idk why
                throw e;
            }  
        }

        public List<FunctionSymbol> FetchFunctions(Scope globalScope)
        {
            IEnumerable<ArduinoSymbolInfo> arduinoFunctionSymbolInfo = Symbols.Where(f => f.ParameterTypes != null);
            List<FunctionSymbol> functionSymbols = new List<FunctionSymbol>();

            foreach(ArduinoSymbolInfo arduinoSymbolInfo in arduinoFunctionSymbolInfo)
            {
                List<Symbol> parameters = new List<Symbol>();
                foreach(var parameter in arduinoSymbolInfo.ParameterTypes)
                {
                    parameters.Add(new Symbol(null, parameter.Name, parameter.Type)); // Can set scope to null since function scope is not part of file.
                }
                functionSymbols.Add(new FunctionSymbol(globalScope, arduinoSymbolInfo.Name, arduinoSymbolInfo.SALType, parameters));
            }
            return functionSymbols;
        }
        public List<Symbol> FetchConstants(Scope globalScope)
        {
            IEnumerable<ArduinoSymbolInfo> arduinoSymbolInfo = Symbols.Where(f => f.ParameterTypes == null);
            List<Symbol> symbols = new List<Symbol>();

            foreach (ArduinoSymbolInfo symbol in arduinoSymbolInfo)
            {
                symbols.Add(new Symbol(globalScope, symbol.Name, symbol.SALType));
            }
            return symbols;
        }
    }
}