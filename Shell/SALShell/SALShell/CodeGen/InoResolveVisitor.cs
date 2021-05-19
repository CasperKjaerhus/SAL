using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SALShell.CodeGen
{
    class InoResolveVisitor : ASTVisitor<InoTypeEnum>
    {
        private Dictionary<Symbol, InoTypeEnum> VariableTypes = new Dictionary<Symbol, InoTypeEnum>();
        private Dictionary<Symbol, InoTypeEnum> FunctionTypes = new Dictionary<Symbol, InoTypeEnum>();
        private Dictionary<Symbol, List<IdAstNode>> ParamDict = new Dictionary<Symbol, List<IdAstNode>>();
        private List<IdAstNode> ParamNodes = new List<IdAstNode>();
        private List<FunctioncallAstNode> CalledFunctions = new List<FunctioncallAstNode>();
        private Symbol CurrentFunction;
        private InoTypeEnum CurrentReturnType;
        private bool IsParam = false;
        private bool IsFirstWalk = true;

        public override InoTypeEnum Visit(ArgumentsAstNode node)
        {
            List<IdAstNode> formalParams = ParamDict[CurrentFunction];
            if (!(formalParams.Any(x => x.InoType == InoTypeEnum.undefined && x.Type == SALTypeEnum.number)))          //If all formal parameters have been resolved RETURN
                return InoTypeEnum.undefined;

            int i = 0;
            InoTypeEnum currentType;

            foreach (ASTNode child in node.Children)
            {
                currentType = Visit(child);
                if(formalParams[i].InoType == InoTypeEnum.undefined && formalParams[i].Type == SALTypeEnum.number)
                {
                    formalParams[i].InoType = currentType;
                }
                i++;
            }

            ParamDict[CurrentFunction] = formalParams;

            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(ArrayAccessAstNode node)
        {
            if (IsFirstWalk)
                return InoTypeEnum.undefined;
            return VariableTypes[node.Symbol];
        }

        public override InoTypeEnum Visit(AssignAstNode node)
        {
            if (node.Symbol.Type == SALTypeEnum.number)
            {
                node.InoType = EvaluateInoAssignment(node);
            }

            return InoTypeEnum.undefined;
        }

        private InoTypeEnum EvaluateInoAssignment(AssignAstNode node)
        {
            InoTypeEnum expressionType = Visit(node.Expr);

            if (VariableTypes.ContainsKey(node.Symbol))
            {
                VariableTypes.TryGetValue(node.Symbol, out InoTypeEnum type);
                if (type == InoTypeEnum.undefined)
                {
                    VariableTypes[node.Symbol] = expressionType;
                }
            }
            else
                VariableTypes.Add(node.Symbol, expressionType);

            return expressionType;
        }

        public override InoTypeEnum Visit(DeclareAstNode node)
        {
            if (node.Symbol.Type == SALTypeEnum.number && IsFirstWalk)
            {
                VariableTypes.Add(node.Symbol, InoTypeEnum.undefined);
            }
            
            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(ExprListAstNode node)
        {
            InoTypeEnum type;
            foreach (ASTNode child in node.Children)
            {
                type = Visit(child);
                if(type == InoTypeEnum.@float)
                {
                    return type;
                }
                type = InoTypeEnum.undefined;
            }

            return InoTypeEnum.@int;
        }

        public override InoTypeEnum Visit(FunctioncallAstNode node)      //Node does not have any symbol rn :/ (Should ideally share symbol with it's declaration)
        {
            if (IsFirstWalk)
                return InoTypeEnum.undefined;

            InoTypeEnum InoType = FunctionTypes[node.Symbol];

            CurrentFunction = node.Symbol;
            node.InoType = InoType;

            if(!(CalledFunctions.Any(x => x == node)))          // If-Statement Makes sure we're not going to evaluate the parameters more than once (first call decides type)
            {
                Visit(node.Arguments);
                CalledFunctions.Add(node);
            }

            return InoType;
        }

        public override InoTypeEnum Visit(FunctionDeclarationAstNode node)
        {
            if (node.Body != null)
            {
                Visit(node.Parameters);
                if (IsFirstWalk)
                {
                    ParamDict.Add(node.Symbol, CopyNodeList(ParamNodes));        //Add the functions current parameters for later checking, then clear it for next time 
                    ParamNodes.Clear();
                }
                Visit(node.Body);
            }
            else
                return InoTypeEnum.undefined;

            if (IsFirstWalk)
            {
                node.InoType = CurrentReturnType;
                FunctionTypes.Add(node.Symbol, CurrentReturnType);
            }

            CurrentReturnType = InoTypeEnum.undefined;

            return InoTypeEnum.undefined;
        }

        private List<IdAstNode> CopyNodeList(List<IdAstNode> paramNodes)
        {
            List<IdAstNode> nodeList = new List<IdAstNode>();
            foreach (IdAstNode node in paramNodes)
            {
                nodeList.Add(node);
            }

            return nodeList;
        }

        //Due to the CFG some not so nice (almost spaghetti-like) code has been created
        //(Namely that formal parameters are ID AST nodes and not Declaration Ast Nodes)
        public override InoTypeEnum Visit(IdAstNode node)
        {
            if (IsParam && IsFirstWalk)
            {
                if(node.Symbol.Type == SALTypeEnum.number) //IF IT IS A SAL-NUMBER ADD IT TO THE EVALUATION QUEUE BY SETTING ISPARAM TO TRUE ELSE IGNORE IT
                {
                    node.IsParam = IsParam;
                    VariableTypes.Add(node.Symbol, InoTypeEnum.undefined);
                }
                return InoTypeEnum.undefined;
            }
            else if(node.Symbol != null && node.Symbol.Type == SALTypeEnum.number)
            {
                VariableTypes.TryGetValue(node.Symbol, out InoTypeEnum val);   //If it is not a parameter-declaration try to find the ino type of the id.
                node.InoType = val;
                return val;
            }

            return InoTypeEnum.undefined;
        }
        public override InoTypeEnum Visit(ForAstNode node)
        {
            Visit(node.Body);
            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(MultAstNode node)
        {
            InoTypeEnum leftval = Visit(node.Left);
            InoTypeEnum rightval = Visit(node.Right);

            if(rightval == InoTypeEnum.@float || leftval == InoTypeEnum.@float)
            {
                return InoTypeEnum.@float;
            }

            return InoTypeEnum.@int;

        }

        public override InoTypeEnum Visit(ParameterListAstNode node)
        {
            IsParam = true;
            foreach (ASTNode param in node.Children)
            {
                if(param is IdAstNode id)
                    ParamNodes.Add(id);
                Visit(param);
            }
            IsParam = false;
            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(PlusAstNode node)
        {
            InoTypeEnum leftval = Visit(node.Left);
            InoTypeEnum rightval = Visit(node.Right);

            if (rightval == InoTypeEnum.@float || leftval == InoTypeEnum.@float)
            {
                return InoTypeEnum.@float;
            }

            return InoTypeEnum.@int;
        }

        public override InoTypeEnum Visit(PostfixExprAstNode node)
        {
            return InoTypeEnum.@int;
        }

        public override InoTypeEnum Visit(PrefixExprAstNode node)
        {
            return InoTypeEnum.@int;
        }

        public override InoTypeEnum Visit(ReturnAstNode node)
        {
            CurrentReturnType = Visit(node.ReturnExpression);
            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(StatementAstNode node)
        {
            foreach (ASTNode child in node.Children)
            {
                _ = Visit(child);
            }

            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(SwitchBodyAstNode node)
        {
            foreach(ASTNode child in node.Children)
            {
                _ = Visit(child);
            }
            return InoTypeEnum.undefined;
        }

        public override InoTypeEnum Visit(ValueAstNode node)
        {
            if (node.Token.Text.Contains("."))
            {
                return InoTypeEnum.@float;
            }
            else
            {
                return InoTypeEnum.@int;
            }
        }

        private void ResolveNumberTypes(ASTNode node)
        {
            if (node is FunctionDeclarationAstNode funcnode)
                ParamNodes = ParamDict[funcnode.Symbol];
            InoTypeEnum inotype;

            switch (node)
            {
                case DeclareAstNode decl:
                    if (decl.Symbol.Type == SALTypeEnum.number)
                    {
                        decl.InoType = VariableTypes[decl.Symbol];
                    }
                    break;
                case FunctionDeclarationAstNode funcDcl:
                    CurrentFunction = funcDcl.Symbol;
                    break;
                case IdAstNode paramnode:
                    if (paramnode.IsParam && paramnode.Symbol.Type == SALTypeEnum.number)
                    {
                        if(VariableTypes[paramnode.Symbol] == InoTypeEnum.undefined)
                        {
                            inotype = ParamNodes.First(x => x.Symbol == paramnode.Symbol).InoType;
                            paramnode.InoType = inotype;
                        }
                    }
                    break;
                case AssignAstNode asmntNode:
                    if(asmntNode.Expr is FunctioncallAstNode funcCallnode)
                    {
                        asmntNode.InoType = funcCallnode.InoType;
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
        public void PopulateAST(ASTNode root)
        {
            _ = Visit(root);
            IsFirstWalk = false;
            _ = Visit(root);

            ResolveNumberTypes(root);
        }
    }
}
