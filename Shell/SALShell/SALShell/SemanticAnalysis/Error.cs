using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SemanticAnalysis
{
    public class Error
    {
        /*TODO: Implement an offending symbol to the message */
        public string Message { get => ErrorMessages[ErrorType] + Line; }
        public int Line { get; }
        public ErrorEnum ErrorType { get; }
        private readonly Dictionary<ErrorEnum, string> ErrorMessages = new Dictionary<ErrorEnum, string>()
        {
            {ErrorEnum.TypeMismatch, $"Type Mismatch on line "},
            {ErrorEnum.ArgumentError, "Argument Error on line "},
            {ErrorEnum.UndeclaredVariable, "Undeclared variable used on line "},
            {ErrorEnum.VariableRedeclaration, "Attempt to redeclare already declared variable on line "}
        };

        public Error(ErrorEnum errortype, int line)
        {
            Line = line;
            ErrorType = errortype;
        }

        
    }
}