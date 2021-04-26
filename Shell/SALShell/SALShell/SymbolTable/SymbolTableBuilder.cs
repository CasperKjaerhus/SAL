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
                    SymbolTable.OpenScope(funcDcl.Id.Token.Text);
                    break;
                case AssignAstNode asmntNode:
                    TypeInfo typeInfAsmnt = symVisitor.Visit(asmntNode);
                    SymbolTable.EnterSymbol(asmntNode.Children[0].Token.Text, typeInfAsmnt);
                    break;
                //case IdAstNode idNode:
                //    TypeInfo typeInfId = symVisitor.Visit(idNode);
                //    SymbolTable.EnterSymbol(idNode.Token.Text, typeInfId);
                //    break;
                case SwitchStructureAstNode switchS:
                    SymbolTable.OpenScope("Switch");
                    break;
                case FunctioncallAstNode funcCallRef: 
                    TypeInfo typeInfFuncCall = symVisitor.Visit(funcCallRef);
                    IdAstNode Idinfo = (IdAstNode)funcCallRef.FunctionId;
                    SymbolTable.EnterSymbol(Idinfo.Token.Text, typeInfFuncCall);
                    break;
                case WhileAstNode WhileAstNode:
                    TypeInfo typeInfWhile = symVisitor.Visit(WhileAstNode);
                    SymbolTable.OpenScope("While");
                    break;
                case DeclareAstNode dclNode:
                    TypeInfo typeInfoDcl = symVisitor.Visit(dclNode);
                    IdAstNode dclId = (IdAstNode)dclNode.Id;
                    SymbolTable.EnterSymbol(dclId.Token.Text, typeInfoDcl);
                    break;
                case ParameterListAstNode paramListNode:
                    foreach (IdAstNode astnode in paramListNode.Children)
                    {
                        SymbolTable.EnterSymbol(astnode.Token.Text, new IdTypeInfo(astnode.Token, astnode.ArraySize, astnode.Type));
                    }
                    break;
                default:
                    break;
            }
            if(node != null)
            {
                foreach (ASTNode astnode in node.Children)
                {
                    if(astnode != null)
                        ProcessNode(astnode);
                }
            }
            if (node is FunctionDeclarationAstNode || node is WhileAstNode || node is SwitchStructureAstNode)
                SymbolTable.CloseScope();
        }

    }
}
