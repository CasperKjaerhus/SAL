using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SALShell.Controller;
using SALShell.Core;
using SALShell.Core.CodeGeneration;
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

            string text = System.IO.File.ReadAllText(@"D:\P4\SAL\Antlr\Test_Parser_src\Test_Parser\Tests\CodeGenTester.txt");
           
            p4Lexer lexer = new p4Lexer(new AntlrInputStream(text));
            CommonTokenStream stream = new CommonTokenStream(lexer);

            p4Parser parser = new p4Parser(stream);
            IParseTree tree = parser.s();

            ASTNode concreteP4Visitor = new ConcreteP4Visitor().Visit(tree);
            concreteP4Visitor?.PrintTrees(0);

            SymTable SymbolTable = new SymTable(concreteP4Visitor);
            CodeEmitter CodeGenerator = new CodeEmitter();

            CodeGenerator.SynthesizeCode(@"D:\P4\SAL\Antlr\Test_Parser_src\Test_Parser\Tests", "test", concreteP4Visitor);
        }
    }
}
