using System.Collections.Generic;
using System.Linq;
using SALShell.Compiler.Parser;
using SALShell.Compiler.Parser.Nodes;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.CodeGen
{
    class CodeGenVisitor : ASTVisitor<string>
    {
        private const string Spaces = "    ";
        public bool IsGlobal { get; set; } = false;
        public bool IsLoop { get; set; } = false;
        private int IndentationDepth = 0;
        private List<Symbol> DeclOrInit = new List<Symbol>();
        public string GlobalVariables { get; private set; } = "";
        private List<ASTNode> AlreadyVisited = new List<ASTNode>();
        public bool HasSetup { get; private set; } = false;

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
                    arguments += Visit(child);
                    if (arguments.Last() == ';')
                    {
                        arguments = arguments.Remove(arguments.Length - 1);
                    }
                    if (child != node.Children[node.Children.Count - 1])
                    {
                        arguments += ", ";
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
            if(!(AlreadyVisited.Any(x => x == node)))
            {
                AlreadyVisited.Add(node);
            }
            else
            {
                return "";
            }


            if (node.Symbol.Scope.Depth == 0 && IsLoop && node.Id is IdAstNode idnode)
            {
                if(idnode.Type != SALTypeEnum.undefined)
                    return "";
            }

            string AssignmentCode = "";
            string expression = Visit(node.Expr);
            string id = Visit(node.Id);

            if(node.InoType != InoTypeEnum.undefined && !(DeclOrInit.Any(x => x == node.Symbol)))
            {
                id = node.InoType + " " + id;
                DeclOrInit.Add(node.Symbol);
            }

            if (expression.Last() == ';')
                AssignmentCode = id + " = " + expression;
            else
                AssignmentCode = id + " = " + expression + ";";

            if(node.Symbol.Scope.Depth == 0 && IsGlobal)
            {
                GlobalVariables += AssignmentCode + "\n";
                return "";
            }

            return AssignmentCode;
        }

        public override string Visit(DeclareAstNode node)
        {
            if(node.Symbol.Scope.Depth == 0 && IsLoop)
            {
                return "";
            }

            if (node.InoType == InoTypeEnum.undefined)
                return "";
            else if(node.Symbol.Type == SALTypeEnum.number)
            {
                DeclOrInit.Add(node.Symbol);
                return node.InoType + " " + Visit(node.Id) + ";";
            }
            else if(node.Symbol.Scope.Depth == 0 && IsGlobal)
            {
                GlobalVariables += Visit(node.Id) + ";" + "\n";
                return "";
            }

            return Visit(node.Id) + ";";
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
            string endVal = Visit(node.EndValue);
            string step = "1";
            IndentationDepth++;
            string body = Visit(node.Body);
            IndentationDepth--;

            if (node.Step != null)
                step = Visit(node.Step);

            string forCode = $"for (int {iterator} = {startVal}; {iterator} <= {endVal}; {iterator} = {iterator} + {step}){{\n{body}}}";

            return forCode;
        }

        public override string Visit(ForeachAstNode node)
        {
            return $"for({Visit(node.ItemId)} : {Visit(node.CollectionId)}){{\n{Spaces}{Visit(node.Body)}}}";
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

            if(node.InoType != InoTypeEnum.undefined)
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

            if(node.Symbol.Name.ToLower() == "setup")
            {
                HasSetup = true;
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

            if (node.Negation)
                IdCode += "!";

            if (node.Type != SALTypeEnum.undefined && node.Type != SALTypeEnum.number)
            {
                IdCode += node.Type + " ";
            }

            else if(node.Type == SALTypeEnum.number && node.InoType != InoTypeEnum.undefined)
            {
                DeclOrInit.Add(node.Symbol); 
                IdCode += node.InoType + " ";
            }

            IdCode += node.Token.Text;

            if (node.ArraySize != null)
            {
                if(node.ArraySize == 0)
                {
                    IdCode += "[]";
                }else
                    IdCode += $"[{node.ArraySize}]";
            }

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
            if(node.Negation)
                return $"!({Visit(node.Left)} {node.Token.Text} {Visit(node.Right)})";
            else
                return $"{Visit(node.Left)} {node.Token.Text} {Visit(node.Right)}";
        }

        public override string Visit(ReturnAstNode node)
        {
            return $"return {Visit(node.ReturnExpression)};";
        }

        public override string Visit(StatementAstNode node)
        {
            string Code = "";
            string CurrentCode = "";

            for (int i = 0; i < IndentationDepth; i++)
            {
                Code += Spaces;
            }

            foreach (ASTNode child in node.Children)
            {
                CurrentCode = Visit(child);

                if (CurrentCode != "")
                {
                    Code += CurrentCode + "\n";
                }
            }

            return Code;
        }

        public override string Visit(SwitchBodyAstNode node)
        {
            string SwitchBody = "";
            foreach (ASTNode child in node.Children)
            {
                SwitchBody += Visit(child);
            }
            return SwitchBody;
        }

        public override string Visit(SwitchItemAstNode node)
        {
            IndentationDepth++;
            string block = Visit(node.Block);
            IndentationDepth--;
            if (node.IsBreaked)
                return $"{Spaces}case {Visit(node.Value)}:\n{block}{Spaces}break;\n";
            else
                return $"{Spaces}case {Visit(node.Value)}:\n{block}";
        }

        public override string Visit(SwitchStructureAstNode node)
        {
            return $"switch({Visit(node.ConditionalValue)}){{\n{Visit(node.SwitchBody)}{Spaces}default:\n{Spaces}break;\n{Spaces}}}";
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
