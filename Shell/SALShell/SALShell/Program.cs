using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SALShell.Controller;
using SALShell.Core;
using SALShell.Parser;
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

            p4Lexer lexer = new p4Lexer(new AntlrInputStream("number ledPins[] = {2, 7, 4, 6, 5, 3};"));
            CommonTokenStream stream = new CommonTokenStream(lexer);

            
            

            p4Parser parser = new p4Parser(stream);
            IParseTree tree = parser.s();

            IList<IToken> asfd = lexer.GetAllTokens();
            Console.WriteLine("AMOUNT: " + asfd.Count);

            foreach(IToken token in asfd)
            {
                Console.WriteLine($"{token.Text} : {lexer.Vocabulary.GetSymbolicName(token.Type)}");
            }
            
            ASTNode concreteP4Visitor = new ConcreteP4Visitor().Visit(tree);
            concreteP4Visitor.PrintTrees(0);
        }
    }
}
