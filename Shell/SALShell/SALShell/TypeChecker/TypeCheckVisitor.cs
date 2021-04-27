using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SALShell.Parser;

namespace SALShell.TypeChecker
{
    class TypeCheckVisitor : ASTVisitor<List<TypeError>>
    {
        public TypeCheckVisitor(ASTNode tree)
        {
            Root = tree;
        }

        public ASTNode Root { get; set; }

        public override List<TypeError> Visit(ArgumentsAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ArrayAccessAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(AssignAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(CondAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(DeclareAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ExprAstNode expr)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ExprListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ForAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ForeachAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(FunctioncallAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(FunctionDeclarationAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(IdAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(IfStructureAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType exprType = RetrieveSymbol(node.Expr);
            if (!exprType.Equals(SALType.@bool))
            {
                errors.Add(new TypeError(node.Token.Line, "If Condition is not of type 'bool'"));
            }

            return errors;
        }

        public override List<TypeError> Visit(ImportStatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(LogicAndAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@bool && e2 != SALType.@bool)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type boolean"));
            }

            return errors;
        }

        public override List<TypeError> Visit(LogicEqualityAstNode node) //TODO what about int vs float?
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@number && e2 != SALType.@number)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type number"));
            }

            return errors;
        }

        public override List<TypeError> Visit(LogicOrAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@bool && e2 != SALType.@bool)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type boolean"));
            }

            return errors;
        }

        public override List<TypeError> Visit(MultAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@number && e2 != SALType.@number)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type number"));
            }

            return errors;
        }

        public override List<TypeError> Visit(ParameterListAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(PlusAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@number && e2 != SALType.@number)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type number"));
            }

            return errors;
        }

        public override List<TypeError> Visit(PostfixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(PrefixExprAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(RelationalExprAstNode node)
        {
            List<TypeError> errors = new List<TypeError>();
            SALType e1 = RetrieveSymbol(node.E1).type;
            SALType e2 = RetrieveSymbol(node.E2).type;
            if (e1 != SALType.@number && e2 != SALType.@number)
            {
                errors.Add(new TypeError(node.Token.Line, "atleast one of e1 and e2 are not of type number"));
            }

            return errors;
        }

        public override List<TypeError> Visit(ReturnAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(StatementAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(SwitchBodyAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(SwitchItemAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(SwitchStructureAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(TypeAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(ValueAstNode node)
        {
            throw new NotImplementedException();
        }

        public override List<TypeError> Visit(WhileAstNode node)
        {
            throw new NotImplementedException();
        }
    }
}
