using Antlr4.Runtime;
using SALShell.Compiler.SymbolTable;

namespace SALShell.Compiler.Parser.Nodes
{
    public class FunctionDeclarationAstNode : ASTNode
    {
        public ASTNode Id { get; }
        public ASTNode Parameters { get; }
        public ASTNode Body { get; }
        public FunctionSymbol Symbol { get; set; }
        public InoTypeEnum InoType { get; set; }

        public FunctionDeclarationAstNode(ASTNode id, ASTNode parameters, ASTNode body, IToken token) : base(token)
        {
            Id = id;
            Parameters = parameters;
            Body = body;

            Children.Add(id);
            Children.Add(parameters);
            Children.Add(body);
        }

        public override string ToString()
        {
            string parameters = "";
            foreach (var par in parameters)
            {
                parameters += parameters.ToString();
            }
            return $"{base.ToString()} params: {parameters}";
        }
    }
}
