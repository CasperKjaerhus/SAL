using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SALShell.Controller;
using SALShell.Core;
using SALShell.Parser;
using SALShell.SymbolTable;
using SALShell.TypeChecker;
using SALShell.UI;

namespace SALShell
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICore core = new Core.Core();
            //IShellUI ui = new ShellCLI();
            //ShellController sheeController = new ShellController(ui, core);
            //sheeController.Ui.Start();

            string text = System.IO.File.ReadAllText(@"D:\Github Repos\SAL\Antlr\Test_Parser_src\Test_Parser\Tests\SymbolTableTest.txt");
            //string text = "function main(number two) returns void begin\n foreach(f in h) begin number g;\n char s;\n end\n end function test() returns void begin end";
            p4Lexer lexer = new p4Lexer(new AntlrInputStream(text));
            CommonTokenStream stream = new CommonTokenStream(lexer);

            //IList<IToken> asfd = lexer.GetAllTokens();
            //Console.WriteLine("AMOUNT: " + asfd.Count);

            //foreach(IToken token in asfd)
            //{
            //    Console.WriteLine($"{token.Text} : {lexer.Vocabulary.GetSymbolicName(token.Type)}");
            //}

            p4Parser parser = new p4Parser(stream);
            IParseTree tree = parser.s();

            ASTNode concreteP4Visitor = new ConcreteP4Visitor().Visit(tree);
            concreteP4Visitor?.PrintTrees(0);

            SymTable symbolTable = new SymTable(concreteP4Visitor);

            if (symbolTable.HasErrors)
                symbolTable.PrintErrors();

            symbolTable.GlobalScope.Print();
        }
    }
}
