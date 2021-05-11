using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALShell.CodeGen
{
    class InoResolveVisitor : ASTVisitor<object>
    {
        private Dictionary<Symbol, string> IdTypes = new Dictionary<Symbol, string>();
        private List<IdAstNode> FormalParameters = new List<IdAstNode>();
        private string CurrentReturnType;
        private bool IsParam = false;

        public override object Visit(ArgumentsAstNode node)
        {
            return null;
        }

        public override object Visit(ArrayAccessAstNode node)
        {
            return null;
        }

        public override object Visit(AssignAstNode node)
        {
            if (node.Symbol.Type == SALTypeEnum.number)
            {
                node.InoType = EvaluateInoAssignment(node);
            }

            return null;
        }

        private string EvaluateInoAssignment(AssignAstNode node)
        {
            string expressionType = "";
            string type;

            expressionType += Visit(node.Expr);

            if (IdTypes.ContainsKey(node.Symbol))
            {
                IdTypes.TryGetValue(node.Symbol, out type);
                if(type == "null")
                {
                    IdTypes[node.Symbol] = expressionType;
                }
            } else
                IdTypes.Add(node.Symbol, expressionType);

            return expressionType;
        }

        public override object Visit(CondAstNode node)
        {
            return null;
        }

        public override object Visit(DeclareAstNode node)
        {
            if (node.Symbol.Type == SALTypeEnum.number)
            {
                IdTypes.Add(node.Symbol, "null");
            }
            
            return null;
        }

        public override object Visit(ExprListAstNode node)
        {
            return null;
        }

        public override object Visit(ForAstNode node)
        {
            return null;
        }

        public override object Visit(ForeachAstNode node)
        {
            return null;
        }

        public override object Visit(FunctioncallAstNode node)
        {
            return null;
        }

        public override object Visit(FunctionDeclarationAstNode node)
        {
            Visit(node.Parameters);
            Visit(node.Body);
            node.InoType = CurrentReturnType;
            CurrentReturnType = "";

            return null;
        }

        //Due to the CFG some not so nice (almost spaghetti-like) code has been created
        //(Namely that formal parameters are ID AST nodes and not Declaration Ast Nodes)
        public override object Visit(IdAstNode node)
        {
            if (IsParam)
            {
                if(node.Symbol.Type == SALTypeEnum.number) //IF IT IS A SAL-NUMBER ADD IT TO THE EVALUATION QUEUE ELSE IGNORE IT
                {
                    FormalParameters.Add(node);
                    IdTypes.Add(node.Symbol, "null");
                }
                return null;
            }
            else
            {
                IdTypes.TryGetValue(node.Symbol, out string val);   //If it is not a parameter-declaration try to find the ino type of the id.
                return val;
            }
        }

        public override object Visit(IfStructureAstNode node)
        {
            return null;
        }

        public override object Visit(ImportStatementAstNode node)
        {
            return null;
        }

        public override object Visit(LogicAndAstNode node)
        {
            return null;
        }

        public override object Visit(EqualityAstNode node)
        {
            return null;
        }

        public override object Visit(LogicOrAstNode node)
        {
            return null;
        }

        public override object Visit(MultAstNode node)
        {
            string leftval = "";
            string rightval = "";
            
            leftval += Visit(node.Left);
            rightval += Visit(node.Right);

            if(rightval == "float" || leftval == "float")
            {
                return "float";
            }

            return "int";

        }

        public override object Visit(ParameterListAstNode node)
        {
            IsParam = true;
            foreach (ASTNode param in node.Children)
            {
                Visit(param);
            }
            IsParam = false;
            return null;
        }

        public override object Visit(PlusAstNode node)
        {
            string leftval = "";
            string rightval = "";

            leftval += Visit(node.Left);
            rightval += Visit(node.Right);

            if (rightval == "float" || leftval == "float")
            {
                return "float";
            }

            return "int";
        }

        public override object Visit(PostfixExprAstNode node)
        {
            return "int";
        }

        public override object Visit(PrefixExprAstNode node)
        {
            return "int";
        }

        public override object Visit(RelationalExprAstNode node)
        {
            return null;
        }

        public override object Visit(ReturnAstNode node)
        {
            CurrentReturnType += Visit(node.ReturnExpression);
            return null;
        }

        public override object Visit(StatementAstNode node)
        {
            foreach (ASTNode child in node.Children)
            {
                Visit(child);
            }

            return null;
        }

        public override object Visit(SwitchBodyAstNode node)
        {
            return null;
        }

        public override object Visit(SwitchItemAstNode node)
        {
            return null;
        }

        public override object Visit(SwitchStructureAstNode node)
        {
            return null;
        }

        public override object Visit(TypeAstNode node)
        {
            return null;
        }

        public override object Visit(ValueAstNode node)
        {
            if (node.Token.Text.Contains("."))
            {
                return "float";
            }
            else
            {
                return "int";
            }
        }

        public override object Visit(WhileAstNode node)
        {
            return null;
        }

        public void ResolveNumberDeclarations(ASTNode node)
        {
            switch (node)
            {
                case DeclareAstNode decl:
                    if (decl.Symbol.Type == SALTypeEnum.number)
                    {
                        decl.InoType = IdTypes[decl.Symbol];
                    }
                    break;
                case IdAstNode paramnode:
                    if (paramnode.Symbol.Type == SALTypeEnum.number && FormalParameters.Any(x => x == paramnode))
                    {
                        paramnode.InoType = IdTypes[paramnode.Symbol];
                    }
                    break;
                default:
                    break;
            }

            if(node != null && node.Children != null)
            {
                foreach (ASTNode child in node.Children)
                {
                    ResolveNumberDeclarations(child);
                }
            }
        }
    }
}
