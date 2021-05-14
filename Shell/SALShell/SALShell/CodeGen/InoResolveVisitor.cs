﻿using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALShell.CodeGen
{
    class InoResolveVisitor : ASTVisitor<string>
    {
        private Dictionary<Symbol, string> VariableTypes = new Dictionary<Symbol, string>();
        private Dictionary<Symbol, string> FunctionTypes = new Dictionary<Symbol, string>();
        private string CurrentReturnType;
        private bool IsParam = false;

        public override string Visit(ArgumentsAstNode node)
        {
            return null;
        }

        public override string Visit(ArrayAccessAstNode node)
        {
            return null;
        }

        public override string Visit(AssignAstNode node)
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

            if (VariableTypes.ContainsKey(node.Symbol))
            {
                VariableTypes.TryGetValue(node.Symbol, out type);
                if (type == "null")
                {
                    VariableTypes[node.Symbol] = expressionType;
                }
            }
            else
                VariableTypes.Add(node.Symbol, expressionType);

            if(node.Expr is ExprListAstNode)                    //If the programmer has not defined arraysize upon initialazation, this function will define it.
                UndefinedArraySizeChecker(node);

            return expressionType;
        }

        private static void UndefinedArraySizeChecker(AssignAstNode node)
        {
            int arraysize = 0;
            if (node.Expr is ExprListAstNode exprNode && node.Id is IdAstNode idNode)
            {
                if (idNode.ArraySize.Text == "[]")
                {
                    foreach (ASTNode child in exprNode.Children)
                    {
                        arraysize++;
                    }
                    idNode.UndefinedArraySize = arraysize;
                }
            }
        }

        public override string Visit(CondAstNode node)
        {
            return null;
        }

        public override string Visit(DeclareAstNode node)
        {
            if (node.Symbol.Type == SALTypeEnum.number)
            {
                VariableTypes.Add(node.Symbol, "null");
            }
            
            return null;
        }

        public override string Visit(ExprListAstNode node)
        {
            string type = "";
            foreach (ASTNode child in node.Children)
            {
                type += Visit(child);
                if(type == "float")
                {
                    return type;
                }
                type = "";
            }

            return "int";
        }

        public override string Visit(ForAstNode node)
        {
            return null;
        }

        public override string Visit(ForeachAstNode node)
        {
            return null;
        }

        public override string Visit(FunctioncallAstNode node)
        {
            return null;
        }

        public override string Visit(FunctionDeclarationAstNode node)
        {
            if (node.Body != null)
            {
                Visit(node.Parameters);
                Visit(node.Body);
            }
            else
                return null;

            node.InoType = CurrentReturnType;
            FunctionTypes.Add(node.Symbol, CurrentReturnType);
            CurrentReturnType = "";

            return null;
        }

        //Due to the CFG some not so nice (almost spaghetti-like) code has been created
        //(Namely that formal parameters are ID AST nodes and not Declaration Ast Nodes)
        public override string Visit(IdAstNode node)
        {
            if (IsParam)
            {
                if(node.Symbol.Type == SALTypeEnum.number) //IF IT IS A SAL-NUMBER ADD IT TO THE EVALUATION QUEUE BY SETTING ISPARAM TO TRUE ELSE IGNORE IT
                {
                    node.IsParam = IsParam;
                    VariableTypes.Add(node.Symbol, "null");
                }
                return null;
            }
            else if(node.Symbol != null && node.Symbol.Type == SALTypeEnum.number)
            {
                VariableTypes.TryGetValue(node.Symbol, out string val);   //If it is not a parameter-declaration try to find the ino type of the id.
                return val;
            }

            return null;
        }

        public override string Visit(IfStructureAstNode node)
        {
            return null;
        }

        public override string Visit(ImportStatementAstNode node)
        {
            return null;
        }

        public override string Visit(LogicAndAstNode node)
        {
            return null;
        }

        public override string Visit(EqualityAstNode node)
        {
            return null;
        }

        public override string Visit(LogicOrAstNode node)
        {
            return null;
        }

        public override string Visit(MultAstNode node)
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

        public override string Visit(ParameterListAstNode node)
        {
            IsParam = true;
            foreach (ASTNode param in node.Children)
            {
                Visit(param);
            }
            IsParam = false;
            return null;
        }

        public override string Visit(PlusAstNode node)
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

        public override string Visit(PostfixExprAstNode node)
        {
            return "int";
        }

        public override string Visit(PrefixExprAstNode node)
        {
            return "int";
        }

        public override string Visit(RelationalExprAstNode node)
        {
            return null;
        }

        public override string Visit(ReturnAstNode node)
        {
            CurrentReturnType += Visit(node.ReturnExpression);
            return null;
        }

        public override string Visit(StatementAstNode node)
        {
            foreach (ASTNode child in node.Children)
            {
                Visit(child);
            }

            return null;
        }

        public override string Visit(SwitchBodyAstNode node)
        {
            return null;
        }

        public override string Visit(SwitchItemAstNode node)
        {
            return null;
        }

        public override string Visit(SwitchStructureAstNode node)
        {
            return null;
        }

        public override string Visit(TypeAstNode node)
        {
            return null;
        }

        public override string Visit(ValueAstNode node)
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

        public override string Visit(WhileAstNode node)
        {
            return null;
        }

        public void ResolveNumberTypes(ASTNode node)
        {
            switch (node)
            {
                case DeclareAstNode decl:
                    if (decl.Symbol.Type == SALTypeEnum.number)
                    {
                        decl.InoType = VariableTypes[decl.Symbol];
                    }
                    break;
                case IdAstNode paramnode:
                    if (paramnode.IsParam && paramnode.Symbol.Type == SALTypeEnum.number)
                    {
                        paramnode.InoType = VariableTypes[paramnode.Symbol];
                    }
                    break;
                case AssignAstNode asmntNode:
                    if(asmntNode.Expr is FunctioncallAstNode funcnode)
                    {
                        asmntNode.InoType = FunctionTypes[funcnode.Symbol];
                    }
                    break;
                default:
                    break;
            }

            if(node != null && node.Children != null)
            {
                foreach (ASTNode child in node.Children)
                {
                    ResolveNumberTypes(child);
                }
            }
        }

    }
}
