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

            if (left != right)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
            }
                
            return left;
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
