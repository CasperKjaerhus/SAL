using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.SemanticAnalysis
{
    static class Error
    {
        public static readonly Dictionary<ErrorEnum, string> Errors = new Dictionary<ErrorEnum, string>()
        {
            {ErrorEnum.TypeMismatch, $"Type Mismatch on "},
            {ErrorEnum.ArgumentError, "Argument Error on "},
            {ErrorEnum.UndeclaredVariable, "Undeclared variable used on "},
            {ErrorEnum.VariableRedeclaration, "Attempt to redeclare already declared variable on "}
        };
    }
}