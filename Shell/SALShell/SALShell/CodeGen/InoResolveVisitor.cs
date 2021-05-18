using SALShell.Parser;
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
        private Dictionary<Symbol, List<IdAstNode>> ParamDict = new Dictionary<Symbol, List<IdAstNode>>();
        private List<IdAstNode> ParamNodes = new List<IdAstNode>();
        private List<FunctioncallAstNode> CalledFunctions = new List<FunctioncallAstNode>();
        private Symbol CurrentFunction;
        private string CurrentReturnType;
        private bool IsParam = false;
        private bool IsFirstWalk = true;

        public override string Visit(ArgumentsAstNode node)
        {
            List<IdAstNode> formalParams = ParamDict[CurrentFunction];
            if (!(formalParams.Any(x => x.InoType == null)))          //If all formal parameters have been resolved RETURN
                return null;

            int i = 0;
            string currentType;

            foreach (ASTNode child in node.Children)
            {
                currentType = Visit(child);
                if(formalParams[i].InoType == null && formalParams[i].Type == SALTypeEnum.number)
                {
                    formalParams[i].InoType = currentType;
                }
                i++;
            }

            ParamDict[CurrentFunction] = formalParams;

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

            expressionType += Visit(node.Expr);

            if (VariableTypes.ContainsKey(node.Symbol))
            {
                VariableTypes.TryGetValue(node.Symbol, out string type);
                if (type == "null")
                {
                    VariableTypes[node.Symbol] = expressionType;
                }
            }
            else
                VariableTypes.Add(node.Symbol, expressionType);

            return expressionType;
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
            Visit(node.Body);
            return null;
        }

        public override string Visit(ForeachAstNode node)
        {
            Visit(node.Body);
            return null;
        }

        public override string Visit(FunctioncallAstNode node)      //Node does not have any symbol rn :/ (Should ideally share symbol with it's declaration)
        {
            if (IsFirstWalk)
                return null;


            string InoType = FunctionTypes[node.Symbol];

            CurrentFunction = node.Symbol;
            node.InoType = InoType;

            if(!(CalledFunctions.Any(x => x == node)))          // If-Statement Makes sure we're not going to evaluate the parameters more than once (first call decides type)
            {
                Visit(node.Arguments);
                CalledFunctions.Add(node);
            }

            return InoType;
        }

        public override string Visit(FunctionDeclarationAstNode node)
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
                return null;

            if (IsFirstWalk)
            {
                if(node.Id is IdAstNode idNode)
                {
                    node.InoType = CurrentReturnType;
                    FunctionTypes.Add(node.Symbol, CurrentReturnType);
                }
            }

            CurrentReturnType = "";

            return null;
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
        public override string Visit(IdAstNode node)
        {
            if (IsParam && IsFirstWalk)
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
                if(param is IdAstNode id)
                    ParamNodes.Add(id);
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
            foreach(ASTNode child in node.Children)
            {
                Visit(child);
            }
            return null;
        }

        public override string Visit(SwitchItemAstNode node)
        {
            Visit(node.Block);
            return null;
        }

        public override string Visit(SwitchStructureAstNode node)
        {
            Visit(node.SwitchBody);
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
            Visit(node.Body);
            return null;
        }

        private void ResolveNumberTypes(ASTNode node)
        {
            if (node is FunctionDeclarationAstNode funcnode)
                ParamNodes = ParamDict[funcnode.Symbol];
            string inotype;

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

                        if(VariableTypes[paramnode.Symbol] == "null" || paramnode.InoType == null)
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
            Visit(root);
            IsFirstWalk = false;
            Visit(root);

            ResolveNumberTypes(root);
        }
    }
}
