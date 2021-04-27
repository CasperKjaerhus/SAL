﻿using Antlr4.Runtime;
using SALShell.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SymbolTable
{
    class SymbolTableVisitor : ASTVisitor<TypeInfo>
    {
        public override TypeInfo Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(AssignAstNode node)
        {
            IdAstNode idNode = (IdAstNode)node.Children[0];
            TypeInfo operationTypeInfo = null;

            switch (node.Children[1])
            {
                case PlusAstNode plus:
                    operationTypeInfo = Visit(plus);
                    break;
                default:
                    break;
            }

            return new AssignmentTypeInfo(idNode.Token, operationTypeInfo, idNode.Type);
        }

        public override TypeInfo Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(DeclareAstNode node)
        {
            IdAstNode id = (IdAstNode)node.Id;
            //if(id.ArraySize != null)
            //    return new DeclTypeInfo(id.Type);
            //else
                return new DeclTypeInfo(id.Type, id.ArraySize);
        }

        public override TypeInfo Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(FunctioncallAstNode node)
        {
            IdAstNode IDinfo = (IdAstNode)node.FunctionId;
            ArgumentsAstNode argumentNode = (ArgumentsAstNode)node.Arguments;
            List<TypeInfo> argus = new List<TypeInfo>();

            foreach (ASTNode child in argumentNode.Children)
            {
                argus.Add(Visit(child));
            }

            return new FuncCallTypeInfo(IDinfo.Type, argus);

        }

        //should return the type, and it's parameters return type
        public override TypeInfo Visit(FunctionDeclarationAstNode node)
        {
            IdAstNode IDinfo = (IdAstNode)node.Id;
            ParameterListAstNode Paraminfo = (ParameterListAstNode)node.Parameters;
            List<IToken> tokens = new List<IToken>();
            foreach (IdAstNode param in Paraminfo.Children)
            {
                tokens.Add(param.Type);
            }

            FuncTypeInfo funcTypeInfo = new FuncTypeInfo(IDinfo.Type, tokens);
            return funcTypeInfo;
        }

        public override TypeInfo Visit(IdAstNode node)
        {
            return new IdTypeInfo(node.Token, node.ArraySize, node.Type);
        }

        public override TypeInfo Visit(IfStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicAndAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicEqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(MultAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(PlusAstNode node)
        {
            return new OperationTypeInfo(Visit(node.Children[0]), Visit(node.Children[1]), node.Token);
        }

        public override TypeInfo Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(RelationalExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ReturnAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(StatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo Visit(ValueAstNode node)
        {
            return new ValueTypeInfo(node.Token);
        }

        public override TypeInfo Visit(WhileAstNode node)
        {
            return Visit(node.Condition);
        }
    }
}