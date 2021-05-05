﻿using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    class SymbolTableBuilder
    {
        private SymTable SymbolTable = new SymTable();
        private SymbolTableVisitor symVisitor = new SymbolTableVisitor();
        private int forloopCount = 0;
        private int WhileCount = 0;
        private int ifCount = 0;
        private int switchCount = 0;
        public ASTNode ASTroot { get; }

        public SymbolTableBuilder(ASTNode root)
        {
            ASTroot = root;
        }


        public SymTable BuildSymbolTable()
        {
            ProcessNode(ASTroot);
            SymbolTable.CheckFunctionReferences();
            return SymbolTable;
        }

        private void ProcessNode(ASTNode node)
        {
            switch (node) //Switches on the type of node, calls the visitor which grabs typeinfo from the ASTNode, then put it into symbol-table using the .EnterSymbol() 
            {
                case FunctionDeclarationAstNode funcDcl:
                    TypeInfo typeInfFuncDcl = symVisitor.Visit(funcDcl);
                    funcDcl.Sym = SymbolTable.EnterSymbol(funcDcl.Id.Token.Text, typeInfFuncDcl);
                    SymbolTable.OpenScope(funcDcl.Id.Token.Text);
                    break;
                case AssignAstNode asmntNode:
                    TypeInfo typeInfAsmnt = symVisitor.Visit(asmntNode);
                    asmntNode.Sym = SymbolTable.EnterSymbol(asmntNode.Children[0].Token.Text, typeInfAsmnt);
                    break;
                case SwitchStructureAstNode switchS:
                    SymbolTable.OpenScope($"{switchCount++}");
                    break;
                case FunctioncallAstNode funcCallRef: 
                    TypeInfo typeInfFuncCall = symVisitor.Visit(funcCallRef);
                    IdAstNode Idinfo = (IdAstNode)funcCallRef.FunctionId;
                    SymbolTable.EnterSymbol(Idinfo.Token.Text, typeInfFuncCall);
                    break;
                case WhileAstNode whileAstNode:
                    SymbolTable.OpenScope($"While{WhileCount++}");
                    break;
                case ForAstNode forAstNode:
                    SymbolTable.OpenScope($"For-loop{forloopCount++}");
                    break;
                case DeclareAstNode dclNode:
                    TypeInfo typeInfoDcl = symVisitor.Visit(dclNode);
                    IdAstNode dclId = (IdAstNode)dclNode.Id;
                    dclNode.Sym = SymbolTable.EnterSymbol(dclId.Token.Text, typeInfoDcl);
                    break;
                case ParameterListAstNode paramListNode:
                    foreach (IdAstNode astnode in paramListNode.Children)
                    {
                       astnode.Sym = SymbolTable.EnterSymbol(astnode.Token.Text, new IdTypeInfo(astnode.ArraySize, astnode.Type));
                    }
                    break;
                case IfStructureAstNode ifStructureAstNode:
                    SymbolTable.OpenScope($"ifStatement{ifCount++}");
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
            if (node is FunctionDeclarationAstNode || node is WhileAstNode || node is SwitchStructureAstNode || node is ForAstNode || node is IfStructureAstNode)
                SymbolTable.CloseScope();
        }
    }
}
