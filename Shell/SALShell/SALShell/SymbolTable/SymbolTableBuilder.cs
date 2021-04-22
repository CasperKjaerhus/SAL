using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
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
            switch (node) //Switches on the type of node
            {
                case FunctionDeclarationAstNode funcDcl:
                    SymbolTable.OpenScope();
                    break;
                case AssignAstNode asmntNode:
                    break;
                case IdAstNode idNode:
                    break;
                case SwitchStructureAstNode switchS:
                    break;
                case FunctioncallAstNode funcCallRef:
                    break;
                case WhileAstNode WhileAstNode:
                    break;
                default:
                    break;
            }
            foreach (ASTNode astnode in node.Children)
            {
                ProcessNode(astnode);
            }
            if (node is FunctionDeclarationAstNode)
                SymbolTable.CloseScope();
        }

    }
}
