using System.Collections.Generic;
using System.Linq;
using SALShell.Compiler.Parser;
using SALShell.Compiler.Parser.Nodes;
using SALShell.Compiler.SemanticAnalysis;

namespace SALShell.Compiler.TypeChecker
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
            return ExpressionCheck(new[] { SALTypeEnum.number }, node.Left, node.Right);
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
            return ExpressionCheck(new []{ SALTypeEnum.@bool, SALTypeEnum.@char, SALTypeEnum.number }, node.Left, node.Right) != SALTypeEnum.error ? SALTypeEnum.@bool : SALTypeEnum.error;
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
        public override SALTypeEnum Visit(LogicAndAstNode node)
        {
            return ExpressionCheck(new[] { SALTypeEnum.@bool }, node.Left, node.Right) != SALTypeEnum.error ? SALTypeEnum.@bool : SALTypeEnum.error;
        }

        public override SALTypeEnum Visit(LogicOrAstNode node)
        {
            return ExpressionCheck(new[] { SALTypeEnum.@bool }, node.Left, node.Right) != SALTypeEnum.error ? SALTypeEnum.@bool : SALTypeEnum.error;
        }
        public override SALTypeEnum Visit(PostfixExprAstNode node)
        {
            SALTypeEnum idType = Visit(node.Id);
            if(idType != SALTypeEnum.number)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
                return SALTypeEnum.error;
            }

            return SALTypeEnum.number;
        }
        public override SALTypeEnum Visit(PrefixExprAstNode node)
        {
            SALTypeEnum idType = Visit(node.Id);
            if (idType != SALTypeEnum.number)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
                return SALTypeEnum.error;
            }

            return SALTypeEnum.number;
        }

        public override SALTypeEnum Visit(ReturnAstNode node)
        {
            if(node.ReturnType != Visit(node.ReturnExpression))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line, node.Token.Text));
                return SALTypeEnum.error;
            }
            return node.ReturnType;
        }

        public override SALTypeEnum Visit(RelationalExprAstNode node)
        {
            return ExpressionCheck(new[] { SALTypeEnum.number }, node.Left, node.Right) != SALTypeEnum.error ? SALTypeEnum.@bool : SALTypeEnum.error;
        }

        public override SALTypeEnum Visit(MultAstNode node)
        {
            return ExpressionCheck(new[] { SALTypeEnum.number }, node.Left, node.Right);
        }
        public override SALTypeEnum Visit(ForeachAstNode node)
        {
            return base.Visit(node);
        }

        public override SALTypeEnum Visit(ArgumentsAstNode node)
        {
            return base.Visit(node);
        }

        public override SALTypeEnum Visit(ASTNode node)
        {
            return base.Visit(node);
        }
        public override SALTypeEnum Visit(CondAstNode node)
        {
            return base.Visit(node);
        }

        private SALTypeEnum ExpressionCheck(SALTypeEnum[] compatibleTypes, ASTNode left, ASTNode right)
        {
            SALTypeEnum leftType = Visit(left);
            if (leftType == SALTypeEnum.error)
                return SALTypeEnum.error;
            SALTypeEnum rightType = Visit(right);
            if (rightType == SALTypeEnum.error)
                return SALTypeEnum.error;
            if (leftType != rightType)
                return SALTypeEnum.error;
            if (!compatibleTypes.ToList().Exists(s => s == leftType))
                return SALTypeEnum.error;

            return leftType;
        }
    }
}
