using System;
using System.Collections.Generic;
using SALShell.Parser;
using SALShell.SemanticAnalysis;
using SALShell.SymbolTable;

namespace SALShell.TypeChecker
{
    class TypeCheckVisitor : ASTVisitor<SALTypeEnum>
    {
        public List<Error> Errors = new List<Error>();
        public TypeCheckVisitor(ASTNode root)
        {
            Visit(root);
        }

        public override SALTypeEnum Visit(AssignAstNode node)
        {
            SALTypeEnum expr = Visit(node.Expr);
            if (expr != node.Symbol.Type)
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Symbol.Name));
            
            return node.Symbol.Type;
        }

        public override SALTypeEnum Visit(PlusAstNode node)
        {
            SALTypeEnum Left = Visit(node.Left);
            if(Left == SALTypeEnum.error)
            {
                return SALTypeEnum.error;
            }
            SALTypeEnum Right = Visit(node.Right);
            if (Right == SALTypeEnum.error)
            {
                return SALTypeEnum.error;
            }
            if(Right != Left || Left != SALTypeEnum.number || Right != SALTypeEnum.number)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
                return SALTypeEnum.error;
            }

            return SALTypeEnum.number;
        }

        public override SALTypeEnum Visit(WhileAstNode node)
        {
            if(Visit(node.Condition) != SALTypeEnum.@bool)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
            }

            Visit(node.Body);

            return default;

        }

        public override SALTypeEnum Visit(ArrayAccessAstNode node)
        {
            if(Visit(node.IndexExpression) != SALTypeEnum.number)
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Symbol.Name));

            return node.Symbol.Type;
        }

        public override SALTypeEnum Visit(EqualityAstNode node)
        {
            SALTypeEnum left = Visit(node.Left);
            SALTypeEnum right = Visit(node.Right);

            if (left != right || left != SALTypeEnum.number && left != SALTypeEnum.@char && left != SALTypeEnum.@bool || right != SALTypeEnum.number && right != SALTypeEnum.@char && right != SALTypeEnum.@bool)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
            }
                
            return SALTypeEnum.@bool;
        }

        public override SALTypeEnum Visit(IfStructureAstNode node)
        {
            if(Visit(node.Condition) != SALTypeEnum.@bool)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
            }

            Visit(node.Body);
            Visit(node.ElseStmt);

            return default;
        }
        public override SALTypeEnum Visit(IdAstNode node)
        {
            return node.Symbol.Type;
        }

        public override SALTypeEnum Visit(FunctioncallAstNode node)
        {
            if(node.Symbol.ParameterSymbols.Count != node.Arguments.Children.Count)
            {
                Errors.Add(new Error(ErrorEnum.ArgumentError, node.FunctionId.Token.Line, node.FunctionId.Token.Text));
            }
            else
            {
                for (int i = 0; i < node.Arguments.Children.Count; i++)
                {
                    if(Visit(node.Arguments.Children[i]) != node.Symbol.ParameterSymbols[i].Type)
                    {
                        Errors.Add(new Error(ErrorEnum.TypeMismatch, node.FunctionId.Token.Line, node.FunctionId.Token.Text));
                    }
                }
            }

            return node.Symbol.Type;
        }

        public override SALTypeEnum Visit(ForAstNode node)
        {
            if(Visit(node.StartValue) != SALTypeEnum.number || Visit(node.EndValue) != SALTypeEnum.number || node.Step != null && Visit(node.Step) != SALTypeEnum.number)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
            }

            Visit(node.Body);

            return default;
        }

        public override SALTypeEnum Visit(ValueAstNode node)
        {
            return node.Type;
        }

        public override SALTypeEnum Visit(ExprListAstNode node)
        {
            List<SALTypeEnum> typesInExprList = new List<SALTypeEnum>();

            foreach (ASTNode child in node.Children)
            {
                typesInExprList.Add(Visit(child));
            }

            if(!typesInExprList.TrueForAll(s => s == typesInExprList[0]))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
                return SALTypeEnum.error;
            }

            return typesInExprList[0];
        }
    }
}
