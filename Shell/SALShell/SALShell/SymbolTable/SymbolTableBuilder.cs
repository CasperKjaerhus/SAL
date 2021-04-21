using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    class SymbolTableBuilder
    {
        SymbolTable SymbolTable = new SymbolTable();

        private ASTNode ASTroot { get; }

        public SymbolTableBuilder(ASTNode root)
        {
            ASTroot = root;
        }


        public SymbolTable BuildSymbolTable()
        {
            ProcessNode(ASTroot);
            return SymbolTable;
        }

        private void ProcessNode(ASTNode node)
        {
            switch (node)             //Switches on the type of node
            {
                case FunctioncallAstNode funcDcl:
                    break;
                default:
                    break;
            }
        }

    }
}
