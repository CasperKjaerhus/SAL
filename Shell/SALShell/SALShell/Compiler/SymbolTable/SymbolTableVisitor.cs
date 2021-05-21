using System.Collections.Generic;
using SALShell.Compiler.Parser;
using SALShell.Compiler.Parser.Nodes;
using SALShell.Compiler.SemanticAnalysis;

namespace SALShell.Compiler.SymbolTable
{
    public class SymbolTableVisitor : ASTVisitor<Symbol>
    {
        private List<Error> Errors { get; }
        private Scope CurrentScope { get; set; }
        private Queue<(ASTNode, Scope)> scopeQueue = new Queue<(ASTNode, Scope)>();
        private Dictionary<string, FunctionSymbol> FunctionSymbols = new Dictionary<string, FunctionSymbol>();

        public SymbolTableVisitor(Scope globalScope, List<Error> errors)
        {
            this.Errors = errors;
            this.CurrentScope = globalScope;
        }

        override public Symbol Visit(StatementAstNode node)
        {
            /*Special case if we're in global scope, since we have to save globals before going into other scopes*/
            Visit(node.Action);
            if (node.NextNode != null)
                Visit(node.NextNode);

            if(CurrentScope.Depth == 0)
            {
                while(scopeQueue.Count != 0)
                {
                    (ASTNode, Scope) functionbody = scopeQueue.Dequeue();
                    CurrentScope = functionbody.Item2;
                    if(functionbody.Item1 != null)
                        Visit(functionbody.Item1);

                    CurrentScope = CurrentScope.Parent;
                }
            }

            return default;
        }

        public override Symbol Visit(ForAstNode node)
        {
            Visit(node.StartValue);
            Visit(node.EndValue);
            if(node.Step != null)
                Visit(node.Step);

            CurrentScope = new Scope(CurrentScope, CurrentScope.Depth + 1);
            node.Scope = CurrentScope;

            Symbol iterator = Visit(node.Iterator);
            if (CurrentScope.RetrieveSymbol(iterator.Name) != null)
                Errors.Add(new Error(ErrorEnum.VariableRedeclaration, node.Token.Line, node.Token.Text));
            CurrentScope.Symbols.Add(iterator);

            if(node.Body != null) // TODO: Error/Warning on empty body
                Visit(node.Body);

            CurrentScope = CurrentScope.Parent;

            return default;
        }

        public override Symbol Visit(AssignAstNode node)
        {
            Symbol idSymbol = Visit(node.Id);

            if(idSymbol != null)
            {
                node.Symbol = idSymbol;

                if(!CurrentScope.IsSymbolWithinScope(idSymbol))
                    CurrentScope.Symbols.Add(idSymbol);
            }

            Visit(node.Expr);

            return idSymbol;
        }

        public override Symbol Visit(FunctionDeclarationAstNode node)
        {
            Symbol IdSymbol = Visit(node.Id);

            CurrentScope = new Scope(CurrentScope, CurrentScope.Depth + 1);

            /*Get all parameter symbols*/
            List<Symbol> parameters = new List<Symbol>();
            foreach(ASTNode argument in node.Parameters.Children)
            {
                Symbol arg = Visit(argument);
                parameters.Add(arg);
                CurrentScope.Symbols.Add(arg);
            }

            FunctionSymbol functionSymbol = new FunctionSymbol(IdSymbol.Scope, IdSymbol.Name, IdSymbol.Type, parameters);
            FunctionSymbols.Add(functionSymbol.Name, functionSymbol);
            CurrentScope.ReturnType = IdSymbol.Type;
            node.Symbol = functionSymbol;

            scopeQueue.Enqueue((node.Body, CurrentScope)); // Queue to scopeQueue so it gets scopechecked after all FunctionDecls

            CurrentScope = CurrentScope.Parent;

            CurrentScope.Symbols.Add(functionSymbol);

            return functionSymbol;
        }

        public override Symbol Visit(ReturnAstNode node)
        {
            node.ReturnType = CurrentScope.ReturnType;
            return base.Visit(node);
        }

        public override Symbol Visit(DeclareAstNode node)
        {
            Symbol idSymbol = Visit(node.Id);
            if (idSymbol != null && !CurrentScope.IsSymbolWithinScope(idSymbol))
            {
                node.Symbol = idSymbol;
                CurrentScope.Symbols.Add(idSymbol);
            }
            return idSymbol;
        }

        public override Symbol Visit(IfStructureAstNode node)
        
        {
            Visit(node.Condition);

            CurrentScope = new Scope(CurrentScope, CurrentScope.Depth + 1);
            node.Scope = CurrentScope;

            Visit(node.Body);

            CurrentScope = CurrentScope.Parent;

            if (node.ElseStmt != null)
                Visit(node.ElseStmt);

            return default;
        }

        public override Symbol Visit(ForeachAstNode node)
        {
            CurrentScope = new Scope(CurrentScope, CurrentScope.Depth + 1);
            node.Scope = CurrentScope;

            Symbol collectionid = Visit(node.CollectionId);
            if(collectionid != null)
            {
                ((IdAstNode)node.ItemId).Type = collectionid.Type; // Neccesarry evil
                Symbol itemId = Visit(node.ItemId);
                CurrentScope.Symbols.Add(itemId);
            }
            
            if (node.Body != null)
                Visit(node.Body);

            CurrentScope = CurrentScope.Parent;

            return default;
        }

        public override Symbol Visit(WhileAstNode node)
        {
            Visit(node.Condition); 

            CurrentScope = new Scope(CurrentScope, CurrentScope.Depth + 1);
            node.Scope = CurrentScope;

            Visit(node.Body);

            CurrentScope = CurrentScope.Parent;

            return default;
        }

        public override Symbol Visit(IdAstNode node)
        {
            if(node.Type != SALTypeEnum.undefined)
            {
                /*Declaration*/
                Symbol newSymbol = new Symbol(CurrentScope, node.Token.Text, node.Type);

                if (CurrentScope.IsSymbolWithinScope(newSymbol))
                {
                    /*Error: Already declared in this scope*/
                    Errors.Add(new Error(ErrorEnum.VariableRedeclaration, node.Token.Line, node.Token.Text));
                    return default;
                }

                node.Symbol = newSymbol;

                return newSymbol;
            }
            else
            {
                /*Assign, Reference, Call etc..*/
                Symbol oldSym = CurrentScope.RetrieveSymbol(node.Token.Text);
                if(oldSym != null)
                {
                    node.Symbol = oldSym;
                    return oldSym; // Symbol was in scope everything is great
                }
                else
                {
                    Errors.Add(new Error(ErrorEnum.UndeclaredVariable, node.Token.Line, node.Token.Text));
                }
                return default;
            }
        }
        public override Symbol Visit(ArrayAccessAstNode node)
        {
            Symbol idSymbol = Visit(node.Id);
            
            if (idSymbol != null)
            {
                node.Symbol = idSymbol;
            }

            Visit(node.IndexExpression);

            return base.Visit(node);
        }

        public override Symbol Visit(FunctioncallAstNode node)
        {
            Symbol s = Visit(node.FunctionId);
            if (s != null)
                node.Symbol = FunctionSymbols[s.Name];

            if(node.Arguments.Children.Count > 0)
            {
                foreach(ASTNode child in node.Arguments.Children)
                {
                    Visit(child);
                }
            }


            return base.Visit(node);
        }
    }
}
