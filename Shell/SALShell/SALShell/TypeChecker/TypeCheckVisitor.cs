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
        private ISymbolTable<Symbol, TypeInfo> SymbolTable { get; set; }
        public TypeCheckVisitor(ISymbolTable<Symbol, TypeInfo> symbolTable)
        {
            SymbolTable = symbolTable;
        }

        
        public override SALTypeEnum Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }   //TODO: cool

        public override SALTypeEnum Visit(ArrayAccessAstNode node)
        {
            SALTypeEnum exprTypeEnum = Visit(node.IndexExpression);
            if (exprTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (exprTypeEnum != SALTypeEnum.number)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return exprTypeEnum;
            }
        }

        public override SALTypeEnum Visit(AssignAstNode node)
        {
            SALTypeEnum idTypeEnum = Visit(node.Id);
            if (idTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum exprTypeEnum = Visit(node.Expr);
            if (exprTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (idTypeEnum != exprTypeEnum)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }

            return idTypeEnum;
        }

        public override SALTypeEnum Visit(CondAstNode node) //TODO: Actually not implemented.
        {
            throw new NotImplementedException();
        }

        public override SALTypeEnum Visit(DeclareAstNode node)
        {
            return SALType.Types[node.Sym.Type.Type.Text];
        }

        public override SALTypeEnum Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: cool

        public override SALTypeEnum Visit(ForAstNode node)
        {
            throw new NotImplementedException();

        } 

        public override SALTypeEnum Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALTypeEnum Visit(FunctioncallAstNode node)
        {
            Symbol FunctionSym = SymbolTable.RetrieveFunction(node.FunctionId.Token.Text);

            SALTypeEnum returnTypeEnum = SALType.Types[FunctionSym.Type.Type.Text];

            FuncTypeInfo f = (FuncTypeInfo) FunctionSym.Type;
            for (int i = 0; i < node.Arguments.Children.Count; i++)
            {
                SALTypeEnum actualArgumentTypeEnum = Visit(node.Arguments.Children[i]);
                if (actualArgumentTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

                if(Visit(node.Arguments.Children[i]) != SALType.Types[f.Parameters[i].Text])
                { 
                    Errors.Add(new Error(ErrorEnum.TypeMismatch, node.FunctionId.Token.Line));
                    returnTypeEnum = SALTypeEnum.error;
                }

            }

            return returnTypeEnum;
        }

        public override SALTypeEnum Visit(FunctionDeclarationAstNode node)
        {
            if(node.Body != null)
                Visit(node.Body);
            
            return SALType.Types[node.Sym.Type.Type.Text];
        }

        public override SALTypeEnum Visit(IdAstNode node)
        {
            return SALType.Types[node.Sym.Type.Type.Text];
        }

        public override SALTypeEnum Visit(IfStructureAstNode node)
        {
            SALTypeEnum exprTypeEnum = Visit(node.Expr);
            if (exprTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (exprTypeEnum != SALTypeEnum.@bool)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }

            return exprTypeEnum;
        }

        public override SALTypeEnum Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }//TODO: cool

        public override SALTypeEnum Visit(LogicAndAstNode node)
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            SALTypeEnum expectedTypeEnum = SALTypeEnum.@bool;
            if (expectedTypeEnum != TypeCheck(expectedTypeEnum, expr1TypeEnum, expr2TypeEnum))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expectedTypeEnum;
            }
        }

        public override SALTypeEnum Visit(EqualityAstNode node)//TODO: What about string type
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (expr1TypeEnum != expr2TypeEnum)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expr1TypeEnum;
            }
        }

        public override SALTypeEnum Visit(LogicOrAstNode node)
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            SALTypeEnum expectedTypeEnum = SALTypeEnum.@bool;
            if (expectedTypeEnum != TypeCheck(expectedTypeEnum, expr1TypeEnum, expr2TypeEnum))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expectedTypeEnum;
            }
        }

        public override SALTypeEnum Visit(MultAstNode node)
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            SALTypeEnum expectedTypeEnum = SALTypeEnum.number;
            if (expectedTypeEnum != TypeCheck(expectedTypeEnum, expr1TypeEnum, expr2TypeEnum))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expectedTypeEnum;
            }
        }

        public override SALTypeEnum Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALTypeEnum Visit(PlusAstNode node)
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            SALTypeEnum expectedTypeEnum = SALTypeEnum.number;
            if (expectedTypeEnum != TypeCheck(expectedTypeEnum, expr1TypeEnum, expr2TypeEnum))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expectedTypeEnum;
            }
        }

        public override SALTypeEnum Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }//TODO: cool

        public override SALTypeEnum Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }//TODO: cool

        public override SALTypeEnum Visit(RelationalExprAstNode node)
        {
            SALTypeEnum expr1TypeEnum = Visit(node.Left);
            if (expr1TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }
            SALTypeEnum expr2TypeEnum = Visit(node.Right);
            if (expr2TypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            SALTypeEnum expectedTypeEnum = SALTypeEnum.@bool;
            if (expectedTypeEnum != TypeCheck(expectedTypeEnum, expr1TypeEnum, expr2TypeEnum))
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }
            else
            {
                return expectedTypeEnum;
            }
        }

        public override SALTypeEnum Visit(ReturnAstNode node) //TODO: lookup function declaration and ensure return type is same as returnvalue type
        {
            throw new NotImplementedException();
        }

        public override SALTypeEnum Visit(StatementAstNode node)
        {
            Visit(node.Action);

            if(node.NextNode != null)
                Visit(node.NextNode);

            return SALTypeEnum.@void;
        } //TODO: cool

        public override SALTypeEnum Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: cool

        public override SALTypeEnum Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: cool

        public override SALTypeEnum Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: cool

        public override SALTypeEnum Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: not cool

        public override SALTypeEnum Visit(ValueAstNode node)
        {
            return node.Type;
        }

        public override SALTypeEnum Visit(WhileAstNode node)
        {
            SALTypeEnum exprTypeEnum = Visit(node.Condition);
            if (exprTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (exprTypeEnum != SALTypeEnum.@bool)
            {
                Errors.Add(new Error(ErrorEnum.TypeMismatch, node.Token.Line));
                return SALTypeEnum.error;
            }

            return exprTypeEnum;
        }

        private SALTypeEnum TypeCheck(SALTypeEnum expected, SALTypeEnum type1, SALTypeEnum type2)
        {
            if (type1 != expected && type2 != expected)
            {
                return SALTypeEnum.error;
            }
            else
            {
                return expected;
            }
        }
    }
}
