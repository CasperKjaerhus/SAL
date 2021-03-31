using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Test_Parser
{
    class P4Parser
    {
        public p4Lexer Lexer {get; private set;}
        public p4Parser Parser { get; private set; }

        public P4Parser(string input, P4ParserErrorListener errorListener)
        {
            ICharStream stream = CharStreams.fromString(input);

            Lexer = new p4Lexer(stream);
            Lexer.RemoveErrorListeners();
            Lexer.AddErrorListener(errorListener);

            ITokenStream tokens = new CommonTokenStream(Lexer);

            Parser = new p4Parser(tokens);
            Parser.RemoveErrorListeners();
            Parser.AddErrorListener(errorListener);
            Parser.BuildParseTree = true;

            Parser.s(); // Run parser on rule s (start rule)
        }

        public void PrintParseTree()
        {
            IParseTree tree = Parser.s();
            Console.WriteLine(tree.ToStringTree());
        }
    }
}
