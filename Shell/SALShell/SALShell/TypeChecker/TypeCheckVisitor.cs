using System;
using System.Collections.Generic;
using SALShell.Parser;
using SALShell.SemanticAnalysis;
using SALShell.SymbolTable;

namespace SALShell.TypeChecker
{
    class TypeCheckVisitor : ASTVisitor<SALTypeEnum>
    {
        public List<string> Errors = new List<string>();
        private SymTable SymbolTable { get; set; }
        private ASTNode Root { get; set; }
        public TypeCheckVisitor(ASTNode tree, SymTable symbolTable)
        {
            Root = tree;
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
            return node.Sym.Type.Type;
        }

        public override SALTypeEnum Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        } //TODO: not cool

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
            SALTypeEnum returnTypeEnum = node.Sym.Type.Type;

            foreach (ASTNode argument in node.Arguments.Children)
            {
                SALTypeEnum actualArgumentTypeEnum = Visit(argument);
                if (actualArgumentTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

                SALTypeEnum declaredParameterTypeEnum;
                Symbol functionSymbol = SymbolTable.RetrieveFunction(node.FunctionId);
                //What to do about the declared type?
                //We need to retrieve definition from symboltable of each param, and compare the actual argument type (line 84) with the declared type from the symbol table.

                if (actualArgumentTypeEnum != declaredParameterTypeEnum)
                {
                    Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
                    returnTypeEnum = SALTypeEnum.error;
                }
            }

            return returnTypeEnum;
        }

        public override SALTypeEnum Visit(FunctionDeclarationAstNode node)
        {
            return node.Sym.Type.Type;
        }

        public override SALTypeEnum Visit(IdAstNode node)
        {
            return node.Sym.Type.Type;
        }

        public override SALTypeEnum Visit(IfStructureAstNode node)
        {
            SALTypeEnum exprTypeEnum = Visit(node.Expr);
            if (exprTypeEnum == SALTypeEnum.error) { return SALTypeEnum.error; }

            if (exprTypeEnum != SALTypeEnum.@bool)
            {
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
            throw new NotImplementedException();
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
                Errors.Add(Error.Errors[ErrorEnum.TypeMismatch] + $" {node.Token.Line}\n");
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
