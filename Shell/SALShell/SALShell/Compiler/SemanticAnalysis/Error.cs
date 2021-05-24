using System.Collections.Generic;

namespace SALShell.Compiler.SemanticAnalysis
{
    public class Error
    {
        /*TODO: Implement an offending symbol to the message */
        public string Message { get => ErrorMessages[ErrorType] + Line + " Offending symbol: " + TokenName; }
        public int Line { get; }
        public string TokenName { get; }
        public ErrorEnum ErrorType { get; }

        private readonly Dictionary<ErrorEnum, string> ErrorMessages = new Dictionary<ErrorEnum, string>()
        {
            {ErrorEnum.TypeMismatch, $"Type Mismatch on line "},
            {ErrorEnum.ArgumentError, "Argument Error on line "},
            {ErrorEnum.UndeclaredVariable, "Undeclared variable used on line "},
            {ErrorEnum.VariableRedeclaration, "Attempt to redeclare already declared variable on line "}
        };

        public Error(ErrorEnum errortype, int line, string tokenName)
        {
            Line = line;
            ErrorType = errortype;
            TokenName = tokenName;
        }

        
    }
}