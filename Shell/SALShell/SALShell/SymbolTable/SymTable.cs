using SALShell.Parser;
using SALShell.SemanticAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    public class SymTable
    {
        private List<Error> Errors { get; set; } = new List<Error>();
        public bool HasErrors => Errors.Count > 0;
        public Scope GlobalScope { get; set; } = new Scope(null, 0);

        public SymTable(ASTNode root)
        {
            SymbolTableVisitor _visitor = new SymbolTableVisitor(GlobalScope, Errors);
            _visitor.Visit(root);
        }

        public void PrintErrors()
        {
            foreach (Error error in Errors)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
