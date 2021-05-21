using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SALShell.Compiler.CodeGen;
using SALShell.Compiler.Parser;
using SALShell.Compiler.ParserGen;
using SALShell.Compiler.SymbolTable;
using SALShell.Compiler.TypeChecker;
using SALShell.Controller;
using SALShell.Core;
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

            string text = System.IO.File.ReadAllText(@"D:\P4\SAL\Antlr\Test_Parser_src\Test_Parser\Tests\CppCompileTest.txt");
           
            p4Lexer lexer = new p4Lexer(new AntlrInputStream(text));
            CommonTokenStream stream = new CommonTokenStream(lexer);

            p4Parser parser = new p4Parser(stream);
            IParseTree tree = parser.s();

            ASTNode AST = new ConcreteP4Visitor().Visit(tree);
            AST?.PrintTrees(0);

            SymTable s = new SymTable(AST);

            s.PrintErrors();
            TypeCheckVisitor t = new TypeCheckVisitor(AST);

            t.Errors.ForEach(s => Console.WriteLine(s.Message));

            CodeEmitter CodeGenerator = new CodeEmitter();

            CodeGenerator.GenerateCode(@"D:\P4\SAL\Antlr\Test_Parser_src\Test_Parser\Tests", "Tests", AST);

        }
    }
}
