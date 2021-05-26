using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SALShell.Compiler.CodeGen;
using SALShell.Compiler.Parser;
using SALShell.Compiler.ParserGen;
using SALShell.Compiler.SymbolTable;
using SALShell.Compiler.TypeChecker;

namespace SALShell.Compiler.Compilation
{
    class Compilation
    {
        public Compilation(string sourcePath, string outputPath, string fileName)
        {
            string text = System.IO.File.ReadAllText(sourcePath); // test available in relative directory: sourcePath = "...\SAL\Antlr\Test_Parser_src\Test_Parser\Tests"

            p4Lexer lexer = new p4Lexer(new AntlrInputStream(text));
            CommonTokenStream stream = new CommonTokenStream(lexer);

            p4Parser parser = new p4Parser(stream);
            IParseTree tree = parser.s();

            ASTNode AST = new ConcreteP4Visitor().Visit(tree);
            AST?.PrintTrees(0);

            //SymTable s = new SymTable(AST);

            //s.PrintErrors();
            //TypeCheckVisitor t = new TypeCheckVisitor(AST);

            //t.Errors.ForEach(s => Console.WriteLine(s.Message));

            //CodeEmitter CodeGenerator = new CodeEmitter();

            //CodeGenerator.GenerateCode(outputPath, fileName, AST);
            //test available in relative directory: 
            //           outputPath = "...\SAL\Antlr\Test_Parser_src\Test_Parser\Tests"
            //           fileName = "Tests"
        }
    }
}
