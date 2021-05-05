using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Parser;

namespace SALShell.SymbolTable
{
    public abstract class TypeInfo
    {
        public IToken Type { get; }
        public TypeInfo(IToken type)
        {
            Type = ResolveType(type);
        }


        private SALType ResolveType(IToken type)
        {
            SALType returnType;
            switch (type?.Text.ToLower())
            {
                case "string":
                    returnType = SALType.@string;
                    break;
                case "number":
                    returnType = SALType.number;
                    break;
                case "true":
                case "false":
                    returnType = SALType.@bool;
                    break;
                case "char":
                    returnType = SALType.@char;
                    break;
                case "void":
                    returnType = SALType.@void;
                    break;
                default:
                    returnType = SALType.error;
                    break;
            }

            return returnType;
        }

        public SALType Type { get; }
    }
}
