﻿using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SALShell.CodeGen
{
    class CodeGenVisitor : ASTVisitor<string>
    {
        private const string Spaces = "    ";
        public bool IsGlobal { get; set; } = false;
        public bool IsLoop { get; set; } = false;
        private int IndentationDepth = 0;

        public override string Visit(ArgumentsAstNode node)
        {
            string arguments = "";
            if (node.Children.Count == 1)
            {
                arguments += Visit(node.Children[0]);
            }
            else
            {
                foreach (ASTNode child in node.Children)
                {
                    arguments += Visit(child) + ", ";
                }
            }

            return arguments;
        }

        public override string Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(AssignAstNode node)
        {
            string expression = Visit(node.Expr);
            string id = Visit(node.Id);

            if (id.Split(" ").Length > 1)
                id = EvaluateInoType(id, expression);

            string AssignmentCode = id +  " = " + expression + ";";

            return AssignmentCode;
        }

        public override string Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(DeclareAstNode node)
        {
            if(node.Sym.ScopeName == "Global" && IsLoop)
            {
                return "";
            }

            return Visit(node.Id) + ";";
        }

        public override string Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(FunctioncallAstNode node)
        {
            return Visit(node.FunctionId) + $"({Visit(node.Arguments)});";
        }

        public override string Visit(FunctionDeclarationAstNode node)
        {
            string id = Visit(node.Id);
            string[] idArr = id.Split(" ");

            if (IsLoop && idArr[1].ToLower() == "main")
            {
                IndentationDepth++;
                string body = Visit(node.Body);
                IndentationDepth--;
                return body;
            }

            if (IsGlobal && idArr[1].ToLower() != "main")
            {
                string parameters = $"({Visit(node.Parameters)})";

                IndentationDepth++;
                string body = Visit(node.Body);
                IndentationDepth--;

                return id + parameters + "{\n" + body + "\n}";
            }
            else
                return "";
        }

        public override string Visit(IdAstNode node)
        {
            string IdCode = "";

            if (node.Type != null)
                IdCode += node.Type.Text + " ";

            IdCode += node.Token.Text;

            if (node.ArraySize != null)
                IdCode += $"[{node.ArraySize}]";

            return IdCode;
        }

        public override string Visit(IfStructureAstNode node)
        {
            string Expr = Visit(node.Expr);
            IndentationDepth++;
            string ElseStatement = "";
            string body = Visit(node.Body);
            IndentationDepth--;
            if (node.ElseStmt == null)
                return $"if({Expr}){{\n{body}{Spaces}}}";
            else if (node.ElseStmt is IfStructureAstNode)
            {
                return $"if({Expr}){{\n{body}{Spaces}}} else {Visit(node.ElseStmt)}";
            }
            else
            {
                IndentationDepth++;
                ElseStatement = Visit(node.ElseStmt);
                IndentationDepth--;
                return $"if({Expr}){{\n{body}{Spaces}}} else{{\n{ElseStatement}\n{Spaces}}}";
            }
        }

        public override string Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(LogicAndAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(EqualityAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(LogicOrAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(MultAstNode node)
        {
            return $"{node.Left.Token.Text} * {node.Right.Token.Text};";
        }

        public override string Visit(ParameterListAstNode node)
        {
            string parameters = "";

            if(node.Children.Count == 1)
            {
                parameters += Visit(node.Children[0]);
            }
            else
            {
                foreach (ASTNode child in node.Children)
                {
                    if (child != node.Children[0])
                        parameters += ", " + Visit(child);
                    else
                    {
                        parameters += Visit(child);
                    }
                }
            }
            return parameters;
        }

        public override string Visit(PlusAstNode node)
        {
            return $"{node.Left.Token.Text} + {node.Right.Token.Text}";
        }

        public override string Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(RelationalExprAstNode node)
        {
            return $"{Visit(node.Left)} {node.Token.Text} {Visit(node.Right)}";
        }

        public override string Visit(ReturnAstNode node)
        {
            return $"return {Visit(node.ReturnExpression)};";
        }

        public override string Visit(StatementAstNode node)
        {
            string Code = "";

            for (int i = 0; i < IndentationDepth; i++)
            {
                Code += Spaces;
            }

            foreach (ASTNode child in node.Children)
            {
                if (Visit(child) != "")
                    Code += Visit(child) + "\n";
            }

            return Code;
        }

        public override string Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(ValueAstNode node)
        {
            return node.Token.Text;
        }

        public override string Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }

        private string EvaluateInoType(string TypeAndId, string Expression)
        {
            string[] IdArr = TypeAndId.Split();
            if (IdArr[0] != "number")
                return TypeAndId;

            string[] ExprArr = Expression.Split(" ");

            if(ExprArr.Length > 1)
            {
                if(ExprArr.Any(x => x == "%"))
                {
                    return "int " + IdArr[1];
                }

            }else if (int.TryParse(Expression, out _))
            {
                return "int " + IdArr[1];
            }else if(float.TryParse(Expression, out _))
            {
                return "float " + IdArr[1];
            }

            return TypeAndId;
        }
        private string FindReferenceType(string reference)
        {
            return reference;
        }
    }
}
