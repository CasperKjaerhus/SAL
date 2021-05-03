using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SALShell.Parser;
using SALShell.SymbolTable;

namespace SALShell.TypeChecker
{
    class TypeCheckVisitor : ASTVisitor<SALType>
    {
        public List<TypeError> TypeErrors = new List<TypeError>();
        private SymbolTableActual SymbolTable;
        public TypeCheckVisitor(ASTNode tree)
        {
            Root = tree;
            SymbolTable = new SymbolTableBuilder(Root).BuildSymbolTable();
        }

        public ASTNode Root { get; set; }

        public override SALType Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(AssignAstNode node)
        {
            SALType idType = Visit(node.Id);
            if (idType == SALType.error) { return SALType.error; }
            SALType exprType = Visit(node.Expr);
            if (exprType == SALType.error) { return SALType.error; }

            if (idType != exprType)
            {
                TypeErrors.Add(new TypeError(node.Token.Line, $"{node.Id.Token.Text} is not same type as {node.Expr.Token.Text}"));
                return SALType.error;
            }

            return idType;
        }

        public override SALType Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(DeclareAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(FunctioncallAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(FunctionDeclarationAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(IdAstNode node)
        {
            //return SymbolTable.RetrieveSymbols(node.Token.Text).Type;
            throw new NotImplementedException();
        }

        public override SALType Visit(IfStructureAstNode node)
        {
            SALType exprType = Visit(node.Expr);
            if (exprType == SALType.error) { return SALType.error; }

            if (exprType != SALType.@bool)
            {
                TypeErrors.Add(new TypeError(node.Token.Line, $"{node.Expr} is not of type bool"));
                return SALType.error;
            }

            return exprType;
        }

        public override SALType Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(LogicAndAstNode node)
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }

            SALType expectedType = SALType.@bool;
            if (expectedType != TypeCheck(expectedType, expr1Type, expr2Type))
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expectedType;
            }
        }

        public override SALType Visit(EqualityAstNode node)//TODO: What about string type
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }

            if (expr1Type != expr2Type)
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expr1Type;
            }
        }

        public override SALType Visit(LogicOrAstNode node)
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }

            SALType expectedType = SALType.@bool;
            if (expectedType != TypeCheck(expectedType, expr1Type, expr2Type))
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expectedType;
            }
        }

        public override SALType Visit(MultAstNode node)
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }

            SALType expectedType = SALType.number;
            if (expectedType != TypeCheck(expectedType, expr1Type, expr2Type))
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expectedType;
            }
        }

        public override SALType Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(PlusAstNode node)
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }
            
            SALType expectedType = SALType.number;
            if (expectedType != TypeCheck(expectedType, expr1Type, expr2Type))
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expectedType;
            }
        }

        public override SALType Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(RelationalExprAstNode node)
        {
            SALType expr1Type = Visit(node.Left);
            if (expr1Type == SALType.error) { return SALType.error; }
            SALType expr2Type = Visit(node.Right);
            if (expr2Type == SALType.error) { return SALType.error; }

            SALType expectedType = SALType.@bool;
            if (expectedType != TypeCheck(expectedType, expr1Type, expr2Type))
            {
                TypeErrors.Add(new TypeError(node.Token.Line,
                    $"{node.Left.Token.Text} is not same type as {node.Right.Token.Text}"));
                return SALType.error;
            }
            else
            {
                return expectedType;
            }
        }

        public override SALType Visit(ReturnAstNode node) //TODO: lookup function declaration and ensure return type is same as returnvalue type
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(StatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override SALType Visit(ValueAstNode node)
        {
            return node.Type;
        }

        public override SALType Visit(WhileAstNode node)
        {
            SALType exprType = Visit(node.Condition);
            if (exprType == SALType.error) { return SALType.error; }

            if (exprType != SALType.@bool)
            {
                TypeErrors.Add(new TypeError(node.Token.Line, $"{node.Condition} is not of type bool"));
                return SALType.error;
            }

            return exprType;
        }

        private SALType TypeCheck(SALType expected, SALType type1, SALType type2)
        {
            if (type1 != expected && type2 != expected)
            {
                return SALType.error;
            }
            else
            {
                return expected;
            }
        }
    }
}
