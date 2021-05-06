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

            //string text = System.IO.File.ReadAllText(@"D:\P4\SAL\Antlr\Test_Parser_src\Test_Parser\Tests\Array_Usage.txt");
            string text = "function boof(char five) returns number begin\n end\n function main(number six) returns void begin\n number f = boof(2+2);\n end";
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

            Console.WriteLine("-----");
            SymTable symbolTable = new SymbolTableBuilder(concreteP4Visitor).BuildSymbolTable();
            symbolTable.PrintSymbols();

            Console.WriteLine("-----");
            TypeCheckVisitor TypeChecker = new TypeCheckVisitor(symbolTable);
            TypeChecker.Visit(concreteP4Visitor);

            ErrorPrinter.Print(TypeChecker.Errors);
            

        }
    }
}
