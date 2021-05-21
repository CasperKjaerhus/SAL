using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SALShell.Compiler.SemanticAnalysis;

namespace SALShell.UI
{
    public static class ErrorPrinter
    {
        public static void Print(IEnumerable<Error> errors)
        {
            IEnumerable<Error> typeErrors =
                from error in errors
                where error.ErrorType == ErrorEnum.TypeMismatch
                select error;

            foreach(Error e in typeErrors)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
