using SALShell.Parser;
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
        private List<Symbol> DeclOrInit = new List<Symbol>();

        public override string Visit(ArgumentsAstNode node)
        {
            string arguments = "";

            if (node.Children.Count == 1)
            {
                arguments += Visit(node.Children[0]);
                if (arguments.Last() == ';')
                {
                    arguments = arguments.Remove(arguments.Length - 1);
                }
            }
            else if(node.Children.Count > 1)
            {
                foreach (ASTNode child in node.Children)
                {
                    arguments += Visit(child) + ", ";
                    if (arguments.Last() == ';')
                    {
                        arguments = arguments.Remove(arguments.Length - 1);
                    }
                }
            } else
                return arguments;

            return arguments;
        }

        public override string Visit(ArrayAccessAstNode node)
        {
            return $"{Visit(node.Id)}[{Visit(node.IndexExpression)}]";
        }

        public override string Visit(AssignAstNode node)
        {
            string AssignmentCode = "";
            string expression = Visit(node.Expr);
            string id = Visit(node.Id);

            if(node.InoType != null && !(DeclOrInit.Any(x => x == node.Symbol)))
            {
                id = node.InoType + " " + id;
            }

            if (expression.Last() == ';')
                AssignmentCode = id + " = " + expression;
            else
                AssignmentCode = id + " = " + expression + ";";

            return AssignmentCode;
        }

        public override string Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override string Visit(DeclareAstNode node)
        {
            if(node.Symbol.Name == "Global" && IsLoop)
            {
                return "";
            }

            if(node.Symbol.Type == SALTypeEnum.number)
            {
                DeclOrInit.Add(node.Symbol);
                return node.InoType + " " + Visit(node.Id) + ";";
            }
            else
            {
                return Visit(node.Id) + ";";
            }
        }

        public override string Visit(ExprListAstNode node)
        {
            string exprListCode = "{ ";

            foreach (ASTNode child in node.Children)
            {
                if(child == node.Children[0])
                    exprListCode += Visit(child);
                else
                    exprListCode += ", " + Visit(child);
            }

            exprListCode += " }";

            return exprListCode;
        }

        public override string Visit(ForAstNode node)
        {
            string iterator = Visit(node.Iterator);
            string startVal = Visit(node.StartValue);
            int endVal = int.Parse(Visit(node.EndValue));
            int step = 1;

            if (node.Step != null && int.TryParse(Visit(node.Step), out _)) 
                step = int.Parse(Visit(node.Step));
            
            string forCode = $"for ({iterator} = {startVal}; {iterator} <= {endVal}; {iterator} = {iterator} + {step})";
            IndentationDepth++;
            forCode += $"{{\n{Visit(node.Body)}{Spaces}}}";
            IndentationDepth--;

            return forCode;
        }

        public override string Visit(ForeachAstNode node)
        {
            return $"for({Visit(node.ItemId)} : {Visit(node.CollectionId)}){{\n{Spaces}}}";
        }

        public override string Visit(FunctioncallAstNode node)
        {
            if(node.Arguments != null)
                return Visit(node.FunctionId) + $"({Visit(node.Arguments)});";
            else
                return Visit(node.FunctionId) + "();";
        }

        public override string Visit(FunctionDeclarationAstNode node)
        {
            string id = Visit(node.Id);
            string body = "";

            if(node.InoType != null)
            {
                id = node.InoType + " " + id;
            }


            if (IsLoop && node.Symbol.Name == "main")
            {
                IndentationDepth++;
                if(node.Body != null)
                    body = Visit(node.Body);
                IndentationDepth--;
                return body;
            }

            if (IsGlobal && node.Symbol.Name != "main")
            {
                string parameters = $"({Visit(node.Parameters)})";
                IndentationDepth++;
                if(node.Body != null)
                    body = Visit(node.Body);
                IndentationDepth--;

                return id + parameters + "{\n" + body + "\n}";
            }
            else
                return "";
        }

        public override string Visit(IdAstNode node)
        {
            string IdCode = "";

            if (node.Type != SALTypeEnum.undefined && node.Type != SALTypeEnum.number)
                IdCode += node.Type + " ";
            else if(node.Type == SALTypeEnum.number && node.InoType != null)
            {
                if (node.IsParam)               //Makes sure that if the Id is used as an assignment it is not set as int or float once again;
                {
                    DeclOrInit.Add(node.Symbol); 
                }
                IdCode += node.InoType + " ";
            }

            IdCode += node.Token.Text;

            if (node.ArraySize != null)
                IdCode += $"{node.ArraySize.Text}";

            return IdCode;
        }

        public override string Visit(IfStructureAstNode node)
        {
            string Condition = Visit(node.Condition);
            IndentationDepth++;
            string ElseStatement = "";
            string body = Visit(node.Body);
            IndentationDepth--;
            if (node.ElseStmt == null)
                return $"if({Condition}){{\n{body}{Spaces}}}";
            else if (node.ElseStmt is IfStructureAstNode)
            {
                return $"if({Condition}){{\n{body}{Spaces}}} else {Visit(node.ElseStmt)}";
            }
            else
            {
                IndentationDepth++;
                ElseStatement = Visit(node.ElseStmt);
                IndentationDepth--;
                return $"if({Condition}){{\n{body}{Spaces}}} else{{\n{ElseStatement}\n{Spaces}}}";
            }
        }

        public override string Visit(ImportStatementAstNode node)
        {
            if (IsGlobal)
                return $"#include {node.Token.Text}";
            else
                return "";
        }

        public override string Visit(LogicAndAstNode node)
        {
            return $"{Visit(node.Left)} && {Visit(node.Right)}";
        }

        public override string Visit(EqualityAstNode node)
        {
            return $"{Visit(node.Left)} == {Visit(node.Right)}";
        }

        public override string Visit(LogicOrAstNode node)
        {
            return $"{Visit(node.Left)} || {Visit(node.Right)}";
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
            return $"{Visit(node.Children[0])}{node.Token.Text}";
        }

        public override string Visit(PrefixExprAstNode node)
        {
            return $"{node.Token.Text}{Visit(node.Children[0])};";
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
            return $"while({Visit(node.Condition)}){{\n{Spaces}{Visit(node.Body)}}}";
        }

    }
}
