using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Antlr4.Runtime;

namespace Test_Parser
{
    class P4ParserErrorListener : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        public string FileName { get; private set; }
        private List<string> _errors = new List<string>();

        public P4ParserErrorListener(string fileName)
        {
            this.FileName = fileName;
        }

        public void HandleErrors()
        {
            if(_errors.Count > 0)
            {
                Console.WriteLine($"Parse errors found in testcase \"{FileName}\"");
                foreach(string error in _errors)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No errors found in testcase: {FileName}");
            }
        }

        void IAntlrErrorListener<int>.SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            _errors.Add($"ERROR @ {line}:{charPositionInLine}: {msg}");
        }

        void IAntlrErrorListener<IToken>.SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            _errors.Add($"ERROR @ {line}:{charPositionInLine}: {msg}");
        }
    }
}
