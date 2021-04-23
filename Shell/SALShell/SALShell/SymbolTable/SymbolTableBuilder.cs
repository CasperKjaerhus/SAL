using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    class SymbolTableBuilder
    {
        SymbolTableActual SymbolTable = new SymbolTableActual();
        SymbolTableVisitor symVisitor = new SymbolTableVisitor();

        private ASTNode ASTroot { get; }

        public SymbolTableBuilder(ASTNode root)
        {
            ASTroot = root;
        }


        public SymbolTableActual BuildSymbolTable()
        {
            ProcessNode(ASTroot);
            return SymbolTable;
        }

        private void ProcessNode(ASTNode node)
        {
            switch (node) //Switches on the type of node
            {
                case FunctionDeclarationAstNode funcDcl:
                    TypeInfo typeInfFuncDcl = symVisitor.Visit(funcDcl);
                    SymbolTable.EnterSymbol(funcDcl.Id.Token.Text, typeInfFuncDcl);
                    SymbolTable.OpenScope();
                    break;
                case AssignAstNode asmntNode:
                    TypeInfo typeInfAsmnt = symVisitor.Visit(asmntNode);
                    SymbolTable.EnterSymbol(asmntNode.Children[0].Token.Text, typeInfAsmnt);
                    break;
                case IdAstNode idNode:
                    //TypeInfo typeInfId = symVisitor.Visit(idNode);
                    //SymbolTable.EnterSymbol(idNode.Token.Text, typeInfId);
                    break;
                case SwitchStructureAstNode switchS:
                    SymbolTable.OpenScope();
                    break;
                case FunctioncallAstNode funcCallRef: 
                    TypeInfo typeInfFuncCallsymVisitor = symVisitor.Visit(funcCallRef);
                    break;
                case WhileAstNode WhileAstNode:
                    TypeInfo typeInfWhile = symVisitor.Visit(WhileAstNode);
                    SymbolTable.OpenScope();
                    break;
                case DeclareAstNode dclNode:
                    TypeInfo typeInfoDcl = symVisitor.Visit(dclNode);
                    IdAstNode dclId = (IdAstNode)dclNode.Id;
                    SymbolTable.EnterSymbol(dclId.Token.Text, typeInfoDcl);
                    break;
                default:
                    break;
            }
            foreach (ASTNode astnode in node.Children)
            {
                ProcessNode(astnode);
            }
            if (node is FunctionDeclarationAstNode || node is WhileAstNode || node is SwitchStructureAstNode)
                SymbolTable.CloseScope();
        }

    }
}
